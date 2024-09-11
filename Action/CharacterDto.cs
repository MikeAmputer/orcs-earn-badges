namespace Action;

[Serializable]
public class CharacterDto
{
	public CharacterStatistics Statistics { get; set; } = new();

	public int ArmorRank { get; set; }

	public int WeaponRank { get; set; }
}
