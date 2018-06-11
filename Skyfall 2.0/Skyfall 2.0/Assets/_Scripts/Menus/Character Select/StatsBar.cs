using UnityEngine;

//resizes the stat bars
//attached to CharacterSelect -> Script Holder - Stats Bar
public class StatsBar : MonoBehaviour
{
    [SerializeField]
    private CharacterSelect cs;

    [Space]

    [SerializeField]
    private GameObject[] statBars = new GameObject[4];

    [Space]

    //Get stats of each class
    [SerializeField]
    private Player[] players = new Player[4];
    private float[] baseHP = new float[4];
    private float[] baseAttack = new float[4];
    private float[] baseDefense = new float[4];
    private int[] baseSpeed = new int[4];

    [Space]

    [SerializeField]
    [Tooltip("Stat bar sprite")]
    private Texture2D tex;
    private Sprite mySprite;
    private SpriteRenderer sr;
    private Vector2 pivot = new Vector2(0.0f, 0.5f);

    void Start()
    {
        sr = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;

        for (int i = 0; i < players.Length; i++)
        {
            baseHP[i] = players[i].health;
            baseAttack[i] = players[i].attack;
            baseDefense[i] = players[i].defense;
            baseSpeed[i] = players[i].moveSpeed;
        }
    }

    void Update()
    {
        sr.sprite = mySprite;
        Resize();
    }

    void Resize()
    {
        for (int i = 0; i < statBars.Length; i++)
        {
            switch (i)
            {
                //red
                case 0:
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].health / Mathf.Max(baseHP)), tex.height), pivot);
                    break;

                //blue
                case 1:
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].attack / Mathf.Max(baseAttack)), tex.height), pivot);
                    break;

                //yellow
                case 2:
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].defense / Mathf.Max(baseDefense)), tex.height), pivot);
                    break;

                //green
                case 3:
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].moveSpeed / Mathf.Max(baseSpeed)), tex.height), pivot);
                    break;
            }

            statBars[i].GetComponent<SpriteRenderer>().sprite = mySprite;
        }
    }

    void SetSprite(float length)
    {

    }
}
