using System.Collections.Generic;

public static class TagManager
{
	private static readonly Dictionary<TagType, string> _tags;

	static TagManager()
	{
		_tags = new Dictionary<TagType, string>
			{
				{TagType.Untagged, "Untagged"},
				{TagType.CollectableCube, "CollectableCube"},
				{TagType.WinTrigger, "WinTrigger"},
				{TagType.Obstacle, "Obstacle"}
			};
	}

	public static string GetTag(TagType tagType)
	{
		return _tags[tagType];
	}
}
