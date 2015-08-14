using Microsoft.VisualStudio.Text.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.VisualStudio.TypescriptClientPackage
{
    public interface ILanguageServiceClientFactory
    {
        ILanguageServiceClient GetLanguageServiceClient(IWpfTextView textView);
    }

    public interface ILanguageServiceClient
    {

    }
}
