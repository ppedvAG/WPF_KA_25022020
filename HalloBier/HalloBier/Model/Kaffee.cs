namespace HalloBier.Model
{
    public class Kaffee
    {
        public string Rösterei { get; set; }
        public int Coffein { get; set; }
        public string Sorte { get; set; }
        public Taste Geschmack { get; set; }
    }

    public enum Taste
    {
        FruityAndFloral,
        Chocolate,
        DryFruits,
        Spicy,
        WoodAndTabacco,
        Caramel,
        MaltAndHoney,
        Biscuit
    }
}
