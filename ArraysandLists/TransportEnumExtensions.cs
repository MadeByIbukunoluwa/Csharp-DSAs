
public static class TransportEnumExtensions
{
    public static char GetChar(this TransportEnum transport)
    {
        // switch expression 
        return transport switch
        {
            TransportEnum.BIKE => 'B',
            TransportEnum.BUS => 'U',
            TransportEnum.CAR => 'C',
            TransportEnum.SUBWAY => 'S',
            TransportEnum.WALK => 'W',
            _ => throw new Exception("Unknown transport"),
        };
    }
    public static ConsoleColor GetColor(this TransportEnum transport)
    {
        switch (transport)
        {
            case TransportEnum.BIKE: return ConsoleColor.Blue;
            case TransportEnum.BUS: return ConsoleColor.DarkGreen;
            case TransportEnum.CAR: return ConsoleColor.Red;
            case TransportEnum.SUBWAY:
                return ConsoleColor.DarkMagenta;
            case TransportEnum.WALK:
                return ConsoleColor.DarkYellow;
            default: throw new Exception("Unknown transport");
        }
    }
}