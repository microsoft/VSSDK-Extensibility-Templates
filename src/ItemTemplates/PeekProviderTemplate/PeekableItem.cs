using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using System;
using System.Collections.Generic;
using System.Threading;

namespace $rootnamespace$
{
    /// <summary>
    /// A <see cref="IPeekableItem"/> is a wrapper around a <see cref="IPeekResultSource"/>
    /// that contains information about which <see cref="IPeekRelationship"/>s it supports, among
    /// other things.
    /// </summary>
    internal class $rootSafeItemName$PeekableItem : IPeekableItem
    {
        internal ITextBuffer TextBuffer { get; }

        internal $rootSafeItemName$PeekableItem(ITextBuffer textBuffer)
        {
            if (textBuffer == null)
            {
                throw new ArgumentNullException(nameof(textBuffer));
            }

            this.TextBuffer = textBuffer;
        }

        public string DisplayName => null;

        public IEnumerable<IPeekRelationship> Relationships
        {
            get
            {
                yield return $rootSafeItemName$.Instance.Value;
            }
        }

        public IPeekResultSource GetOrCreateResultSource(string relationshipName)
        {
            // Make sure we actually apply to the relationshipName that is passed in.
            if (relationshipName.Equals($rootSafeItemName$.RelationshipName, StringComparison.OrdinalIgnoreCase))
            {
                return new ResultSource(this);
            }

            return null;
        }

        /// <summary>
        /// Called by the running <see cref="IPeekBroker"/> to create <see cref="IPeekResult"/>s
        /// that will be displayed to the user in the Peek window.
        /// </summary>
        private class ResultSource : IPeekResultSource
        {
            private readonly $rootSafeItemName$PeekableItem item;

            public ResultSource($rootSafeItemName$PeekableItem item)
            {
                this.item = item;
            }

            /// <summary>
            /// Populates the collection of <see cref="IPeekResult"/>s for the given relationship.
            /// </summary>
            /// <param name="relationshipName">The case insenitive name of the relationship to be queried for results.</param>
            /// <param name="resultCollection">Represents a collection of <see cref="IPeekResult"/>s to be populated.</param>
            /// <param name="cancellationToken">The cancellation token used by the caller to cancel the operation.</param>
            /// <param name="callback">The <see cref="IFindPeekResultsCallback"/> instance used to report progress and failures.</param>
            public void FindResults(string relationshipName, IPeekResultCollection collection, CancellationToken cancellationToken, IFindPeekResultsCallback callback)
            {
                if (relationshipName.Equals($rootSafeItemName$.RelationshipName, StringComparison.OrdinalIgnoreCase))
                {
                    // todo: Add IPeekResults to IPeekResultCollection
                }
            }
        }
    }
}
