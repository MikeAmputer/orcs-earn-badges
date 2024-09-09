namespace Action.Badges;

public class ReactionsGold : Badge
{
	protected override string Image => "reactions-gold";

	protected override string Alt => "Reactions Gold";

	protected override string Description => "Earn 100 heart emojis on your character issue";

	public override bool IsAchieved(CharacterData data) => data.Issue.Reactions.Heart >= 100;
	public override bool IsUpgraded(CharacterData data) => false;
}
