using EnvDTE;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Process = System.Diagnostics.Process;

namespace Microsoft.VisualStudio.TypescriptClientPackage
{
    internal sealed class TypescriptLanguageServiceClientMessenger
    {
        // Todo: don't hardcode in node exe
        public const string NodeExecutableLocation = @"C:\node\node.exe";

        // Todo: don't hardcode in tsserver location
        public const string TSServerFile = @"C:\Users\alexey\AppData\Local\Code\app-0.3.2\resources\app\plugins\vs.language.typescript\lib\tsserver.js";

        internal static readonly TypescriptLanguageServiceClientMessenger Instance = new TypescriptLanguageServiceClientMessenger();

        private Process serverProcess;
        private IList<TypescriptLanguageServiceClient> attachedClients;
        private DTE Dte;

        private TypescriptLanguageServiceClientMessenger()
        {
            this.Dte = Package.GetGlobalService(typeof(DTE)) as DTE;
            this.Dte.Events.DTEEvents.OnBeginShutdown += OnVSShutdown;
            this.serverProcess = Process.Start(ServerProcessStartInfo);
            this.serverProcess.Exited += ServerProcessExited;
            this.attachedClients = new List<TypescriptLanguageServiceClient>();
        }

        private void OnVSShutdown()
        {
            this.Close();
        }

        private void ServerProcessExited(object sender, EventArgs e)
        {
            if (!this.IsClosed)
            {
                // exe terminated unexpectedly, try to disconnect and then create a new instance
                if (this.serverProcess != null)
                {
                    try
                    {
                        this.serverProcess.Close();
                        this.serverProcess.Exited -= ServerProcessExited;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }

                this.serverProcess = Process.Start(ServerProcessStartInfo);
                this.serverProcess.Exited += ServerProcessExited;
            }
        }

        internal void AttachClient(TypescriptLanguageServiceClient client)
        {
            Requires.NotNull(client, nameof(client));
            attachedClients.Add(client);
        }

        internal void DetachClient(TypescriptLanguageServiceClient client)
        {
            Requires.NotNull(client, nameof(client));
            attachedClients.Remove(client);
        }

        internal void Close()
        {
            this.IsClosed = true;
            if (this.serverProcess != null)
            {
                try
                {
                    this.serverProcess.Kill();
                    this.serverProcess.Close();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                finally
                {
                    this.serverProcess = null;
                }
            }
        }

        internal bool IsClosed
        {
            get; private set;
        }

        private static ProcessStartInfo ServerProcessStartInfo
        {
            get
            {
                return new ProcessStartInfo(NodeExecutableLocation, TSServerFile)
                {
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = false
                };
            }
        }
    }
}
