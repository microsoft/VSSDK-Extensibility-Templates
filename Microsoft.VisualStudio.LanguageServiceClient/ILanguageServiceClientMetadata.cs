using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.VisualStudio.TypescriptClientPackage
{
    public interface ILanguageServiceClientMetadata
    {
        IEnumerable<string> SupportedExtensions { get; }
    }
}
