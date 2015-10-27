using Microsoft.VisualStudio.Text.Editor;
using System.ComponentModel.Composition;
using System.Diagnostics;

namespace Microsoft.VisualStudio.TypescriptClientPackage
{
    [Export(typeof(ILanguageServiceClientFactory))]
    [LanguageServiceType(".ts")]
    public class TypescriptLanguageServiceClientFactory : ILanguageServiceClientFactory
    {

        public ILanguageServiceClient GetLanguageServiceClient(IWpfTextView textView)
        {
            Requires.NotNull(textView, nameof(textView));
            var client = new TypescriptLanguageServiceClient(textView);
            TypescriptLanguageServiceClientMessenger.Instance.AttachClient(client);
            return client;
        }
    }

    public class TypescriptLanguageServiceClient : ILanguageServiceClient
    {
        private IWpfTextView textView;

        public TypescriptLanguageServiceClient(IWpfTextView textView)
        {
            Requires.NotNull(textView, nameof(textView));
            this.textView = textView;
            this.textView.Closed += TextViewClosed;
        }

        private void TextViewClosed(object sender, System.EventArgs e)
        {
            TypescriptLanguageServiceClientMessenger.Instance.DetachClient(this);
        }
    }
}
