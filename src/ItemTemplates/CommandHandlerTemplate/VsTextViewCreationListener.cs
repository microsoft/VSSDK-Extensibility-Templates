using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace $rootnamespace$
{
    [Export(typeof(IVsTextViewCreationListener))]
    [ContentType("text")]
    [TextViewRole(PredefinedTextViewRoles.Editable)]
    internal sealed class $rootSafeItemName$TextViewCreationListener : IVsTextViewCreationListener
    {
        [Import]
        private IVsEditorAdaptersFactoryService EditorAdaptersFactoryService { get; set; }

        public void VsTextViewCreated(IVsTextView textViewAdapter)
        {
            IWpfTextView textView = this.EditorAdaptersFactoryService.GetWpfTextView(textViewAdapter);

            $rootSafeItemName$ commandFilter = new $rootSafeItemName$(textView);
            IOleCommandTarget next;
            textViewAdapter.AddCommandFilter(commandFilter, out next);

            commandFilter.Next = next;
        }
    }
}
