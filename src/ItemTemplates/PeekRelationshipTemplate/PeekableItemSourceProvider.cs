using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Utilities;
using System;
using System.ComponentModel.Composition;
using System.Collections.Generic;

namespace $rootnamespace$
{
    /// <summary>
    /// Exports a <see cref="IPeekableItemSourceProvider"/> for the "code" content type.
    /// </summary>
    [Export(typeof(IPeekableItemSourceProvider))]
    [ContentType("code")]
    [Name("$rootSafeItemName$")]
    [SupportsPeekRelationship($rootSafeItemName$.RelationshipName)]
    public class $rootSafeItemName$PeekableItemSourceProvider : IPeekableItemSourceProvider
    {
        public IPeekableItemSource TryCreatePeekableItemSource(ITextBuffer textBuffer)
        {
            return new $rootSafeItemName$PeekableItemSource(textBuffer);
        }
    }

    /// <summary>
    /// A <see cref="IPeekableItemSource"/> is created for each <see cref="ITextBuffer"/>
    /// in a Visual Studio session.
    /// </summary>
    internal class $rootSafeItemName$PeekableItemSource : IPeekableItemSource
    {
        private ITextBuffer textBuffer;

        internal $rootSafeItemName$PeekableItemSource(ITextBuffer textBuffer)
        {
            this.textBuffer = textBuffer;
        }

        /// <summary>
        /// Called by a <see cref="IPeekBroker"/> to add <see cref="IPeekableItem"/>s to a current
        /// <see cref="IPeekSession"/>.
        /// </summary>
        /// <remarks>
        /// The <see cref="IPeekBroker"/> does not know if the <see cref="IPeekableItemSource"/>
        /// supports the relationship in <see cref="IPeekSession"/>, so you should always check to
        /// see if the relationship actually applies to this class.
        /// </remarks>
        /// <param name="session">The running <see cref="IPeekSession"/>.</param>
        /// <param name="peekableItems">A list of <see cref="IPeekableItem"/>s to append to.</param>
        public void AugmentPeekSession(IPeekSession session, IList<IPeekableItem> peekableItems)
        {
            // Only add a new $rootSafeItemName$PeekableItem if the relationship is a $rootSafeItemName$
            if (session.RelationshipName.Equals($rootSafeItemName$.RelationshipName, StringComparison.OrdinalIgnoreCase))
            {
                peekableItems.Add(new $rootSafeItemName$PeekableItem(textBuffer));
            }
        }

        public void Dispose()
        {

        }
    }
}