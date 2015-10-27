using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Microsoft.VisualStudio.TypescriptClientPackage
{
    [Export(typeof(IWpfTextViewCreationListener))]
    [ContentType("text")]
    [TextViewRole(PredefinedTextViewRoles.Document)]
    internal sealed class TextViewListener : IWpfTextViewCreationListener
    {
        [Import]
        internal ITextDocumentFactoryService TextDocumentService = null;

        [ImportMany]
        internal IEnumerable<Lazy<ILanguageServiceClientFactory, ILanguageServiceClientMetadata>> LanguageServiceClientExports = null;

        public void TextViewCreated(IWpfTextView textView)
        {
            Requires.NotNull(textView, nameof(textView));

            string ext;
            if (this.TryGetExtensionFromTextView(textView, out ext))
            {
                foreach (var languageServiceClientExport in this.LanguageServiceClientExports)
                {
                    if (languageServiceClientExport.Metadata.SupportedExtensions.Contains(ext, StringComparer.OrdinalIgnoreCase))
                    {
                        Debug.WriteLine("Found matching language service client!");
                        var languageServiceClient = languageServiceClientExport.Value.GetLanguageServiceClient(textView);
                    }
                }
            }
            else
            {
                Debug.WriteLine("Could not retrieve extension from text buffer");
            }
        }

        private bool TryGetExtensionFromTextView(IWpfTextView textView, out string ext)
        {
            Requires.NotNull(textView, nameof(textView));

            string filePath = string.Empty;
            if (textView.TextDataModel == null)
            {
                ext = string.Empty;
                return false;
            }

            if (textView.TextDataModel != null)
            {
                ITextDocument document;
                if (!TextDocumentService.TryGetTextDocument(textView.TextBuffer, out document))
                {
                    ext = string.Empty;
                    return false;
                }

                filePath = document.FilePath;
            }

            ext = Path.GetExtension(filePath);
            return true;
        }
    }
}
