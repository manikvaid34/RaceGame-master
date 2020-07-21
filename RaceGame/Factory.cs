namespace RaceGame
{
    public static class Factory
    {

        public static int PunterCount { get; set; } = 0;


        public static Punter GetPunter(int Id)
        {
            switch (Id)
            {
                case 0:
                    return new Ram();
                case 1:
                    return new Sita();
                case 2:
                    return new Ali();
                    //default:
                    //    throw new ArgumentOutOfRangeException(nameof(Id), Id, null);
            }
            return new Ram();
        }

        public static Animal GetAnimal(int Id)
        {
            switch (Id)
            {
                case 0:
                    return new Browny();
                case 1:
                    return new Blacky();
                case 2:
                    return new Wolfy();
                case 3:
                    return new RedBurn();
                case 4:
                    return new Foxy();
                case 5:
                    return new Pinky();


                    //default:
                    //    throw new ArgumentOutOfRangeException(nameof(Id), Id, null);
            }
            return new Browny();
        }
    }
}
