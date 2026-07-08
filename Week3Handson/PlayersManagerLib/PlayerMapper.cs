namespace PlayersManagerLib
{
    public class PlayerMapper : IPlayerMapper
    {
        // Note: kept simple (no real DB code) since it isn't used in mocked tests anyway.
        public bool IsPlayerNameExistsInDb(string name)
        {
            // Real implementation would query the database here.
            return false;
        }

        public void AddNewPlayerIntoDb(string name)
        {
            // Real implementation would insert into the database here.
        }
    }
}