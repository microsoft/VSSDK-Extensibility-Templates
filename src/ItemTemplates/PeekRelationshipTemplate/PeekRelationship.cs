using Microsoft.VisualStudio.Language.Intellisense;

namespace $rootnamespace$
{
    /// <summary>
    /// Represents a PeekRelationship matching $rootSafeItemName$. <see cref="IPeekRelationship"/>s
    /// are unique identifiers that apply to a <see cref="IPeekableItemSourceProvider"/>.
    /// </summary>
    public class $rootSafeItemName$ : IPeekRelationship
    {
        private $rootSafeItemName$() { }

        public const string RelationshipName = "$rootSafeItemName$";

        public string DisplayName => $rootSafeItemName$.RelationshipName;

        public string Name => $rootSafeItemName$.RelationshipName;

        public static readonly $rootSafeItemName$ Instance = new $rootSafeItemName$();
    }
}
