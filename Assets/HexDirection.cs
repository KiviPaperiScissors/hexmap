
/* Enum: HexDirection
 * 
 * The edges of a hexagon.
 * 
 * NE   - Northeast
 * E    - East
 * SE   - Southeast
 * SW   - Southwest
 * W    - West
 * NW   - Northwest
 */

public enum HexDirection
{
    NE, E, SE, SW, W, NW
}

// Class: HexDirectionExtensions
// This static class provides a service to find the opposite direction when
// passed a given direction.


public static class HexDirectionExtensions
{
    // Function: Opposite
    // Returns: 
    //  The opposite HexDirection to the one given.

    public static HexDirection Opposite (this HexDirection direction)
    {
        return (int)direction < 3 ? (direction + 3) : (direction - 3);
    }
}