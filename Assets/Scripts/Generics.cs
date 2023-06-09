using UnityEngine;


namespace Lumens {
/// <summary> A static container of all Lumens' generic values. </summary>
public static class Generic {

    /// <summary> Adds a component to the monobehaviour while preventing duplicates. </summary>
    public static COMPONENT TryAddComponent<COMPONENT>(this GameObject x)
    where COMPONENT : Component {

        COMPONENT component = x.GetComponent<COMPONENT>();
        if (component) return component;
        else           return x.gameObject.AddComponent<COMPONENT>();
        
    } // COMPONENT ..


    /// <summary> Adds a child component to the monobehaviour while preventing duplicates. </summary>
    public static COMPONENT TryAddComponentInChildren<COMPONENT>(this GameObject x)
    where COMPONENT : Component {

        COMPONENT component = x.GetComponentInChildren<COMPONENT>();
        
        if (component) return component;
        else return new GameObject(typeof(COMPONENT).Name, typeof(COMPONENT))
            .GetComponent<COMPONENT>();

    } // COMPONENT ..


    /// <summary> Adds a child component to the monobehaviour while preventing duplicates. </summary>
    public static COMPONENT TryAddComponentInChildren<COMPONENT>(this GameObject x, GameObject componentInstance)
    where COMPONENT : Component {

        COMPONENT component = x.GetComponentInChildren<COMPONENT>();
        
        if (component) return component;
        else return GameObject.Instantiate(componentInstance, x.transform)
            .TryAddComponent<COMPONENT>();

    } // COMPONENT ..


    /// <summary> A type which represents all combination of higher planes intersections. </summary>
    public enum PlaneLayer {
        White  = 0b0001,
        Red    = 0b0011,
        Yellow = 0b0101,
        Orange = 0b0111,
        Blue   = 0b1001,
        Purple = 0b1011,
        Green  = 0b1101,
        Black  = 0b1111,
    } // enum ..


    public const int PLANE_MASK_OFFSET = 15;
    public const int PLANE_MASK        = 0b1111 << PLANE_MASK_OFFSET;

    public const int DEFAULT = 0;
    public const int WHITE   = 15;
    public const int RED     = 16;
    public const int YELLOW  = 17;
    public const int BLUE    = 18;

    public const int DEFAULT_LAYER = 1 << DEFAULT;
    public const int SPECIAL_LAYER = 1 << 12;
    public const int FLOOR_LAYER   = 1 << 13;
    public const int TARGET_LAYER  = 1 << 14;
    public const int WHITE_LAYER   = 1 << WHITE;
    public const int RED_LAYER     = 1 << RED;
    public const int YELLOW_LAYER  = 1 << YELLOW;
    public const int BLUE_LAYER    = 1 << BLUE;
    

    /// <summary> A 32 bit encoded colour associated with plane. </summary>
    public static Color32 PlaneColor(PlaneLayer planeType) => PLANE_COLOR_LOOKUP[(int)planeType >> 1];

    /// <summary> A 32 bit encoded colour associated with a plane mask. </summary>
    public static Color32 PlaneColor(int planeLayer) => PLANE_COLOR_LOOKUP[planeLayer];


    private static readonly Color32[] PLANE_COLOR_LOOKUP = new Color32[8] {
        new Color32(255, 255, 255, 255), // 000 WHITE
        new Color32(255, 000, 000, 255), // 001 RED
        new Color32(255, 255, 000, 255), // 010 YELLOW
        new Color32(255, 127, 000, 255), // 011 ORANGE
        new Color32(000, 000, 255, 255), // 100 BLUE
        new Color32(160, 032, 240, 255), // 101 PURPLE
        new Color32(000, 255, 000, 255), // 110 GREEN
        new Color32(000, 000, 000, 255)  // 111 BLACK
    }; // Color32[]
}} // namespace ..
