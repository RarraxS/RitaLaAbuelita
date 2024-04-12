using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Cuchillo_2 : MonoBehaviour
{
    string _zona;
    public int ganar = 0;
    private int num = 0;
    private int vidas = 6;

    [SerializeField] GameObject canvasGameOver;
    [SerializeField] GameObject canvasWinGame;

    [SerializeField] GameObject Boton;

    [SerializeField] GameObject ZanahoriaSinCorte;

    //Ganar=1
    [SerializeField] GameObject ZanahoriaCorte1;
    [SerializeField] GameObject ZanahoriaCorte2;
    [SerializeField] GameObject ZanahoriaCorte3;
    [SerializeField] GameObject ZanahoriaCorte4;
    [SerializeField] GameObject ZanahoriaCorte5;
    [SerializeField] GameObject ZanahoriaCorte6;

    //Ganar=2
    [SerializeField] GameObject ZanahoriaCorte12;
    [SerializeField] GameObject ZanahoriaCorte13;
    [SerializeField] GameObject ZanahoriaCorte14;
    [SerializeField] GameObject ZanahoriaCorte15;
    [SerializeField] GameObject ZanahoriaCorte16;
    [SerializeField] GameObject ZanahoriaCorte23;
    [SerializeField] GameObject ZanahoriaCorte24;
    [SerializeField] GameObject ZanahoriaCorte25;
    [SerializeField] GameObject ZanahoriaCorte26;
    [SerializeField] GameObject ZanahoriaCorte34;
    [SerializeField] GameObject ZanahoriaCorte35;
    [SerializeField] GameObject ZanahoriaCorte36;
    [SerializeField] GameObject ZanahoriaCorte45;
    [SerializeField] GameObject ZanahoriaCorte46;
    [SerializeField] GameObject ZanahoriaCorte56;

    //Ganar=3
    [SerializeField] GameObject ZanahoriaCorte123;
    [SerializeField] GameObject ZanahoriaCorte124;
    [SerializeField] GameObject ZanahoriaCorte125;
    [SerializeField] GameObject ZanahoriaCorte126;
    [SerializeField] GameObject ZanahoriaCorte134;
    [SerializeField] GameObject ZanahoriaCorte135;
    [SerializeField] GameObject ZanahoriaCorte136;
    [SerializeField] GameObject ZanahoriaCorte145;
    [SerializeField] GameObject ZanahoriaCorte146;
    [SerializeField] GameObject ZanahoriaCorte156;
    [SerializeField] GameObject ZanahoriaCorte234;
    [SerializeField] GameObject ZanahoriaCorte235;
    [SerializeField] GameObject ZanahoriaCorte236;
    [SerializeField] GameObject ZanahoriaCorte245;
    [SerializeField] GameObject ZanahoriaCorte246;
    [SerializeField] GameObject ZanahoriaCorte256;
    [SerializeField] GameObject ZanahoriaCorte345;
    [SerializeField] GameObject ZanahoriaCorte346;
    [SerializeField] GameObject ZanahoriaCorte356;
    [SerializeField] GameObject ZanahoriaCorte456;

    //Ganar=4
    [SerializeField] GameObject ZanahoriaCorte1234;
    [SerializeField] GameObject ZanahoriaCorte1235;
    [SerializeField] GameObject ZanahoriaCorte1236;
    [SerializeField] GameObject ZanahoriaCorte1245;
    [SerializeField] GameObject ZanahoriaCorte1246;
    [SerializeField] GameObject ZanahoriaCorte1256;
    [SerializeField] GameObject ZanahoriaCorte1345;
    [SerializeField] GameObject ZanahoriaCorte1346;
    [SerializeField] GameObject ZanahoriaCorte1356;
    [SerializeField] GameObject ZanahoriaCorte1456;
    [SerializeField] GameObject ZanahoriaCorte2345;
    [SerializeField] GameObject ZanahoriaCorte2346;
    [SerializeField] GameObject ZanahoriaCorte2356;
    [SerializeField] GameObject ZanahoriaCorte2456;
    [SerializeField] GameObject ZanahoriaCorte3456;

    //Ganar=4
    [SerializeField] GameObject ZanahoriaCorte12345;
    [SerializeField] GameObject ZanahoriaCorte12356;
    [SerializeField] GameObject ZanahoriaCorte12346;
    [SerializeField] GameObject ZanahoriaCorte12456;
    [SerializeField] GameObject ZanahoriaCorte13456;
    [SerializeField] GameObject ZanahoriaCorte23456;

    //Ganar=6
    [SerializeField] GameObject ZanahoriaConCortes;

    string uno = "Correcto1";
    string dos = "Correcto2";
    string tres = "Correcto3";
    string cuatro = "Correcto4";
    string cinco = "Correcto5";
    string seis = "Correcto6";


    // Start is called before the first frame update
    void Start()
    {
        canvasGameOver.SetActive(false);
        canvasWinGame.SetActive(false);

        Boton.gameObject.SetActive(true);

        _zona = string.Empty;

        ZanahoriaSinCorte.SetActive(true);

        //Ganar=1
        ZanahoriaCorte1.SetActive(false);
        ZanahoriaCorte2.SetActive(false);
        ZanahoriaCorte3.SetActive(false);
        ZanahoriaCorte4.SetActive(false);
        ZanahoriaCorte5.SetActive(false);
        ZanahoriaCorte6.SetActive(false);

        //Ganar=2
        ZanahoriaCorte12.SetActive(false);
        ZanahoriaCorte13.SetActive(false);
        ZanahoriaCorte14.SetActive(false);
        ZanahoriaCorte15.SetActive(false);
        ZanahoriaCorte16.SetActive(false);
        ZanahoriaCorte23.SetActive(false);
        ZanahoriaCorte24.SetActive(false);
        ZanahoriaCorte25.SetActive(false);
        ZanahoriaCorte26.SetActive(false);
        ZanahoriaCorte34.SetActive(false);
        ZanahoriaCorte35.SetActive(false);
        ZanahoriaCorte36.SetActive(false);
        ZanahoriaCorte45.SetActive(false);
        ZanahoriaCorte46.SetActive(false);
        ZanahoriaCorte56.SetActive(false);

        //Ganar=3
        ZanahoriaCorte123.SetActive(false);
        ZanahoriaCorte124.SetActive(false);
        ZanahoriaCorte125.SetActive(false);
        ZanahoriaCorte126.SetActive(false);
        ZanahoriaCorte134.SetActive(false);
        ZanahoriaCorte135.SetActive(false);
        ZanahoriaCorte136.SetActive(false);
        ZanahoriaCorte145.SetActive(false);
        ZanahoriaCorte146.SetActive(false);
        ZanahoriaCorte156.SetActive(false);
        ZanahoriaCorte234.SetActive(false);
        ZanahoriaCorte235.SetActive(false);
        ZanahoriaCorte236.SetActive(false);
        ZanahoriaCorte245.SetActive(false);
        ZanahoriaCorte246.SetActive(false);
        ZanahoriaCorte256.SetActive(false);
        ZanahoriaCorte345.SetActive(false);
        ZanahoriaCorte346.SetActive(false);
        ZanahoriaCorte356.SetActive(false);
        ZanahoriaCorte456.SetActive(false);

        //Ganar=4
        ZanahoriaCorte1234.SetActive(false);
        ZanahoriaCorte1235.SetActive(false);
        ZanahoriaCorte1236.SetActive(false);
        ZanahoriaCorte1245.SetActive(false);
        ZanahoriaCorte1246.SetActive(false);
        ZanahoriaCorte1256.SetActive(false);
        ZanahoriaCorte1345.SetActive(false);
        ZanahoriaCorte1346.SetActive(false);
        ZanahoriaCorte1456.SetActive(false);
        ZanahoriaCorte2345.SetActive(false);
        ZanahoriaCorte2346.SetActive(false);
        ZanahoriaCorte2356.SetActive(false);
        ZanahoriaCorte2456.SetActive(false);
        ZanahoriaCorte3456.SetActive(false);
        ZanahoriaCorte1356.SetActive(false);

        //Ganar=5
        ZanahoriaCorte12345.SetActive(false);
        ZanahoriaCorte12356.SetActive(false);
        ZanahoriaCorte12346.SetActive(false);
        ZanahoriaCorte12456.SetActive(false);
        ZanahoriaCorte13456.SetActive(false);
        ZanahoriaCorte23456.SetActive(false);

        //Ganar=6
        ZanahoriaConCortes.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _zona = collision.tag;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _zona = string.Empty;
    }

    public void Corte()
    {
        if (_zona != string.Empty)
        {
            ganar++;

            //Debug.Log(ganar);

            if (ganar == 1)
            {
                if (_zona == uno)
                {
                    ZanahoriaSinCorte.gameObject.SetActive(false);
                    ZanahoriaCorte1.SetActive(true);
                    num = 1;
                }
                if (_zona == dos)
                {
                    ZanahoriaSinCorte.gameObject.SetActive(false);
                    ZanahoriaCorte2.SetActive(true);
                    num = 2;
                }
                if (_zona == tres)
                {
                    ZanahoriaSinCorte.gameObject.SetActive(false);
                    ZanahoriaCorte3.SetActive(true);
                    num = 3;
                }
                if (_zona == cuatro)
                {
                    ZanahoriaSinCorte.gameObject.SetActive(false);
                    ZanahoriaCorte4.SetActive(true);
                    num = 4;
                }
                if (_zona == cinco)
                {
                    ZanahoriaSinCorte.gameObject.SetActive(false);
                    ZanahoriaCorte5.SetActive(true);
                    num = 5;
                }
                if (_zona == seis)
                {
                    ZanahoriaSinCorte.gameObject.SetActive(false);
                    ZanahoriaCorte6.SetActive(true);
                    num = 6;
                }
            }

            if (ganar == 2)
            {
                if (_zona == uno) //Corte num 1
                {
                    if (num == 2)
                    {
                        ZanahoriaCorte2.gameObject.SetActive(false);
                        ZanahoriaCorte12.SetActive(true);
                        num = 12;
                    }
                    if (num == 3)
                    {
                        ZanahoriaCorte3.gameObject.SetActive(false);
                        ZanahoriaCorte13.SetActive(true);
                        num = 13;
                    }
                    if (num == 4)
                    {
                        ZanahoriaCorte4.gameObject.SetActive(false);
                        ZanahoriaCorte14.SetActive(true);
                        num = 14;
                    }
                    if (num == 5)
                    {
                        ZanahoriaCorte5.gameObject.SetActive(false);
                        ZanahoriaCorte15.SetActive(true);
                        num = 15;
                    }
                    if (num == 6)
                    {
                        ZanahoriaCorte6.gameObject.SetActive(false);
                        ZanahoriaCorte16.SetActive(true);
                        num = 16;
                    }
                }
                if (_zona == dos) //Corte num 2
                {
                    if (num == 1)
                    {
                        ZanahoriaCorte1.gameObject.SetActive(false);
                        ZanahoriaCorte12.SetActive(true);
                        num = 12;
                    }
                    if (num == 3)
                    {
                        ZanahoriaCorte3.gameObject.SetActive(false);
                        ZanahoriaCorte23.SetActive(true);
                        num = 23;
                    }
                    if (num == 4)
                    {
                        ZanahoriaCorte4.gameObject.SetActive(false);
                        ZanahoriaCorte24.SetActive(true);
                        num = 24;
                    }
                    if (num == 5)
                    {
                        ZanahoriaCorte5.gameObject.SetActive(false);
                        ZanahoriaCorte25.SetActive(true);
                        num = 25;
                    }
                    if (num == 6)
                    {
                        ZanahoriaCorte6.gameObject.SetActive(false);
                        ZanahoriaCorte26.SetActive(true);
                        num = 26;
                    }
                }
                if (_zona == tres) //Corte num 3
                {
                    if (num == 1)
                    {
                        ZanahoriaCorte1.gameObject.SetActive(false);
                        ZanahoriaCorte13.SetActive(true);
                        num = 13;
                    }
                    if (num == 2)
                    {
                        ZanahoriaCorte2.gameObject.SetActive(false);
                        ZanahoriaCorte23.SetActive(true);
                        num = 23;
                    }
                    if (num == 4)
                    {
                        ZanahoriaCorte4.gameObject.SetActive(false);
                        ZanahoriaCorte34.SetActive(true);
                        num = 34;
                    }
                    if (num == 5)
                    {
                        ZanahoriaCorte5.gameObject.SetActive(false);
                        ZanahoriaCorte35.SetActive(true);
                        num = 35;
                    }
                    if (num == 6)
                    {
                        ZanahoriaCorte6.gameObject.SetActive(false);
                        ZanahoriaCorte36.SetActive(true);
                        num = 36;
                    }
                }
                if (_zona == cuatro) //Corte num 4
                {
                    if (num == 1)
                    {
                        ZanahoriaCorte1.gameObject.SetActive(false);
                        ZanahoriaCorte14.SetActive(true);
                        num = 14;
                    }
                    if (num == 2)
                    {
                        ZanahoriaCorte2.gameObject.SetActive(false);
                        ZanahoriaCorte24.SetActive(true);
                        num = 24;
                    }
                    if (num == 3)
                    {
                        ZanahoriaCorte3.gameObject.SetActive(false);
                        ZanahoriaCorte34.SetActive(true);
                        num = 34;
                    }
                    if (num == 5)
                    {
                        ZanahoriaCorte5.gameObject.SetActive(false);
                        ZanahoriaCorte45.SetActive(true);
                        num = 45;
                    }
                    if (num == 6)
                    {
                        ZanahoriaCorte6.gameObject.SetActive(false);
                        ZanahoriaCorte46.SetActive(true);
                        num = 46;
                    }
                }
                if (_zona == cinco) //Corte num 5
                {
                    if (num == 1)
                    {
                        ZanahoriaCorte1.gameObject.SetActive(false);
                        ZanahoriaCorte15.SetActive(true);
                        num = 15;
                    }
                    if (num == 2)
                    {
                        ZanahoriaCorte2.gameObject.SetActive(false);
                        ZanahoriaCorte25.SetActive(true);
                        num = 25;
                    }
                    if (num == 3)
                    {
                        ZanahoriaCorte3.gameObject.SetActive(false);
                        ZanahoriaCorte35.SetActive(true);
                        num = 35;
                    }
                    if (num == 4)
                    {
                        ZanahoriaCorte4.gameObject.SetActive(false);
                        ZanahoriaCorte45.SetActive(true);
                        num = 45;
                    }
                    if (num == 6)
                    {
                        ZanahoriaCorte6.gameObject.SetActive(false);
                        ZanahoriaCorte56.SetActive(true);
                        num = 56;
                    }
                }
                if (_zona == seis) //Corte num 6
                {
                    if (num == 1)
                    {
                        ZanahoriaCorte1.gameObject.SetActive(false);
                        ZanahoriaCorte16.SetActive(true);
                        num = 16;
                    }
                    if (num == 2)
                    {
                        ZanahoriaCorte2.gameObject.SetActive(false);
                        ZanahoriaCorte26.SetActive(true);
                        num = 26;
                    }
                    if (num == 3)
                    {
                        ZanahoriaCorte3.gameObject.SetActive(false);
                        ZanahoriaCorte36.SetActive(true);
                        num = 36;
                    }
                    if (num == 4)
                    {
                        ZanahoriaCorte4.gameObject.SetActive(false);
                        ZanahoriaCorte46.SetActive(true);
                        num = 45;
                    }
                    if (num == 5)
                    {
                        ZanahoriaCorte5.gameObject.SetActive(false);
                        ZanahoriaCorte56.SetActive(true);
                        num = 56;
                    }
                }
            }

            if (ganar == 3)
            {
                if (_zona == uno) //Corte num 1
                {
                    if (num == 23)
                    {
                        ZanahoriaCorte23.gameObject.SetActive(false);
                        ZanahoriaCorte123.SetActive(true);
                        num = 123;
                    }
                    if (num == 24)
                    {
                        ZanahoriaCorte24.gameObject.SetActive(false);
                        ZanahoriaCorte124.SetActive(true);
                        num = 124;
                    }
                    if (num == 25)
                    {
                        ZanahoriaCorte25.gameObject.SetActive(false);
                        ZanahoriaCorte125.SetActive(true);
                        num = 125;
                    }
                    if (num == 26)
                    {
                        ZanahoriaCorte26.gameObject.SetActive(false);
                        ZanahoriaCorte126.SetActive(true);
                        num = 126;
                    }
                    if (num == 34)
                    {
                        ZanahoriaCorte34.gameObject.SetActive(false);
                        ZanahoriaCorte134.SetActive(true);
                        num = 134;
                    }
                    if (num == 35)
                    {
                        ZanahoriaCorte35.gameObject.SetActive(false);
                        ZanahoriaCorte135.SetActive(true);
                        num = 135;
                    }
                    if (num == 36)
                    {
                        ZanahoriaCorte36.gameObject.SetActive(false);
                        ZanahoriaCorte136.SetActive(true);
                        num = 136;
                    }
                    if (num == 45)
                    {
                        ZanahoriaCorte45.gameObject.SetActive(false);
                        ZanahoriaCorte145.SetActive(true);
                        num = 145;
                    }
                    if (num == 46)
                    {
                        ZanahoriaCorte46.gameObject.SetActive(false);
                        ZanahoriaCorte146.SetActive(true);
                        num = 146;
                    }
                    if (num == 56)
                    {
                        ZanahoriaCorte56.gameObject.SetActive(false);
                        ZanahoriaCorte156.SetActive(true);
                        num = 156;
                    }
                }
                if (_zona == dos) //Corte num 2
                {
                    if (num == 13)
                    {
                        ZanahoriaCorte13.gameObject.SetActive(false);
                        ZanahoriaCorte123.SetActive(true);
                        num = 123;
                    }
                    if (num == 14)
                    {
                        ZanahoriaCorte14.gameObject.SetActive(false);
                        ZanahoriaCorte124.SetActive(true);
                        num = 134;
                    }
                    if (num == 15)
                    {
                        ZanahoriaCorte15.gameObject.SetActive(false);
                        ZanahoriaCorte125.SetActive(true);
                        num = 125;
                    }
                    if (num == 16)
                    {
                        ZanahoriaCorte16.gameObject.SetActive(false);
                        ZanahoriaCorte126.SetActive(true);
                        num = 126;
                    }
                    if (num == 34)
                    {
                        ZanahoriaCorte34.gameObject.SetActive(false);
                        ZanahoriaCorte234.SetActive(true);
                    }
                    if (num == 35)
                    {
                        ZanahoriaCorte35.gameObject.SetActive(false);
                        ZanahoriaCorte235.SetActive(true);
                        num = 235;
                    }
                    if (num == 36)
                    {
                        ZanahoriaCorte36.gameObject.SetActive(false);
                        ZanahoriaCorte236.SetActive(true);
                        num = 236;
                    }
                    if (num == 45)
                    {
                        ZanahoriaCorte45.gameObject.SetActive(false);
                        ZanahoriaCorte245.SetActive(true);
                        num = 245;
                    }
                    if (num == 46)
                    {
                        ZanahoriaCorte46.gameObject.SetActive(false);
                        ZanahoriaCorte246.SetActive(true);
                        num = 246;
                    }
                    if (num == 56)
                    {
                        ZanahoriaCorte56.gameObject.SetActive(false);
                        ZanahoriaCorte256.SetActive(true);
                        num = 256;
                    }
                }
                if (_zona == tres) //Corte num 3
                {
                    if (num == 12)
                    {
                        ZanahoriaCorte12.gameObject.SetActive(false);
                        ZanahoriaCorte123.SetActive(true);
                        num = 123;
                    }
                    if (num == 14)
                    {
                        ZanahoriaCorte14.gameObject.SetActive(false);
                        ZanahoriaCorte134.SetActive(true);
                        num = 134;
                    }
                    if (num == 15)
                    {
                        ZanahoriaCorte15.gameObject.SetActive(false);
                        ZanahoriaCorte135.SetActive(true);
                        num = 135;
                    }
                    if (num == 16)
                    {
                        ZanahoriaCorte16.gameObject.SetActive(false);
                        ZanahoriaCorte136.SetActive(true);
                        num = 136;
                    }
                    if (num == 24)
                    {
                        ZanahoriaCorte24.gameObject.SetActive(false);
                        ZanahoriaCorte234.SetActive(true);
                        num = 234;
                    }
                    if (num == 25)
                    {
                        ZanahoriaCorte25.gameObject.SetActive(false);
                        ZanahoriaCorte235.SetActive(true);
                        num = 235;
                    }
                    if (num == 26)
                    {
                        ZanahoriaCorte26.gameObject.SetActive(false);
                        ZanahoriaCorte236.SetActive(true);
                        num = 236;
                    }
                    if (num == 45)
                    {
                        ZanahoriaCorte45.gameObject.SetActive(false);
                        ZanahoriaCorte345.SetActive(true);
                        num = 345;
                    }
                    if (num == 46)
                    {
                        ZanahoriaCorte46.gameObject.SetActive(false);
                        ZanahoriaCorte246.SetActive(true);
                        num = 246;
                    }
                    if (num == 56)
                    {
                        ZanahoriaCorte56.gameObject.SetActive(false);
                        ZanahoriaCorte356.SetActive(true);
                        num = 356;
                    }
                }
                if (_zona == cuatro) //Corte num 4
                {
                    if (num == 12)
                    {
                        ZanahoriaCorte12.gameObject.SetActive(false);
                        ZanahoriaCorte124.SetActive(true);
                        num = 124;
                    }
                    if (num == 13)
                    {
                        ZanahoriaCorte13.gameObject.SetActive(false);
                        ZanahoriaCorte134.SetActive(true);
                        num = 134;
                    }
                    if (num == 15)
                    {
                        ZanahoriaCorte15.gameObject.SetActive(false);
                        ZanahoriaCorte145.SetActive(true);
                        num = 145;
                    }
                    if (num == 16)
                    {
                        ZanahoriaCorte16.gameObject.SetActive(false);
                        ZanahoriaCorte146.SetActive(true);
                        num = 146;
                    }
                    if (num == 23)
                    {
                        ZanahoriaCorte23.gameObject.SetActive(false);
                        ZanahoriaCorte234.SetActive(true);
                        num = 234;
                    }
                    if (num == 25)
                    {
                        ZanahoriaCorte25.gameObject.SetActive(false);
                        ZanahoriaCorte245.SetActive(true);
                        num = 245;
                    }
                    if (num == 26)
                    {
                        ZanahoriaCorte26.gameObject.SetActive(false);
                        ZanahoriaCorte246.SetActive(true);
                        num = 246;
                    }
                    if (num == 35)
                    {
                        ZanahoriaCorte35.gameObject.SetActive(false);
                        ZanahoriaCorte345.SetActive(true);
                        num = 345;
                    }
                    if (num == 36)
                    {
                        ZanahoriaCorte36.gameObject.SetActive(false);
                        ZanahoriaCorte346.SetActive(true);
                        num = 346;
                    }
                    if (num == 56)
                    {
                        ZanahoriaCorte56.gameObject.SetActive(false);
                        ZanahoriaCorte456.SetActive(true);
                        num = 456;
                    }
                }
                if (_zona == cinco) //Corte num 5
                {
                    if (num == 12)
                    {
                        ZanahoriaCorte12.gameObject.SetActive(false);
                        ZanahoriaCorte125.SetActive(true);
                        num = 125;
                    }
                    if (num == 13)
                    {
                        ZanahoriaCorte13.gameObject.SetActive(false);
                        ZanahoriaCorte135.SetActive(true);
                        num = 135;
                    }
                    if (num == 14)
                    {
                        ZanahoriaCorte14.gameObject.SetActive(false);
                        ZanahoriaCorte145.SetActive(true);
                        num = 145;
                    }
                    if (num == 16)
                    {
                        ZanahoriaCorte16.gameObject.SetActive(false);
                        ZanahoriaCorte156.SetActive(true);
                        num = 156;
                    }
                    if (num == 23)
                    {
                        ZanahoriaCorte23.gameObject.SetActive(false);
                        ZanahoriaCorte235.SetActive(true);
                        num = 235;
                    }
                    if (num == 24)
                    {
                        ZanahoriaCorte24.gameObject.SetActive(false);
                        ZanahoriaCorte245.SetActive(true);
                        num = 245;
                    }
                    if (num == 26)
                    {
                        ZanahoriaCorte26.gameObject.SetActive(false);
                        ZanahoriaCorte256.SetActive(true);
                        num = 256;
                    }
                    if (num == 34)
                    {
                        ZanahoriaCorte34.gameObject.SetActive(false);
                        ZanahoriaCorte345.SetActive(true);
                        num = 345;
                    }
                    if (num == 36)
                    {
                        ZanahoriaCorte36.gameObject.SetActive(false);
                        ZanahoriaCorte356.SetActive(true);
                        num = 356;
                    }
                    if (num == 46)
                    {
                        ZanahoriaCorte46.gameObject.SetActive(false);
                        ZanahoriaCorte456.SetActive(true);
                        num = 456;
                    }
                }
                if (_zona == seis) //Corte num 6
                {
                    if (num == 12)
                    {
                        ZanahoriaCorte12.gameObject.SetActive(false);
                        ZanahoriaCorte126.SetActive(true);
                        num = 126;
                    }
                    if (num == 13)
                    {
                        ZanahoriaCorte13.gameObject.SetActive(false);
                        ZanahoriaCorte136.SetActive(true);
                        num = 136;
                    }
                    if (num == 15)
                    {
                        ZanahoriaCorte15.gameObject.SetActive(false);
                        ZanahoriaCorte156.SetActive(true);
                        num = 156;
                    }
                    if (num == 14)
                    {
                        ZanahoriaCorte14.gameObject.SetActive(false);
                        ZanahoriaCorte146.SetActive(true);
                        num = 146;
                    }
                    if (num == 23)
                    {
                        ZanahoriaCorte23.gameObject.SetActive(false);
                        ZanahoriaCorte236.SetActive(true);
                        num = 236;
                    }
                    if (num == 25)
                    {
                        ZanahoriaCorte25.gameObject.SetActive(false);
                        ZanahoriaCorte256.SetActive(true);
                        num = 256;
                    }
                    if (num == 24)
                    {
                        ZanahoriaCorte24.gameObject.SetActive(false);
                        ZanahoriaCorte246.SetActive(true);
                        num = 246;
                    }
                    if (num == 35)
                    {
                        ZanahoriaCorte35.gameObject.SetActive(false);
                        ZanahoriaCorte356.SetActive(true);
                        num = 356;
                    }
                    if (num == 34)
                    {
                        ZanahoriaCorte34.gameObject.SetActive(false);
                        ZanahoriaCorte346.SetActive(true);
                        num = 346;
                    }
                    if (num == 45)
                    {
                        ZanahoriaCorte45.gameObject.SetActive(false);
                        ZanahoriaCorte456.SetActive(true);
                        num = 456;
                    }
                }
            }

            if (ganar == 4) //Corte 4
            {
                if (_zona == uno) //Corte num 1
                {
                    if (num == 234)
                    {
                        ZanahoriaCorte234.gameObject.SetActive(false);
                        ZanahoriaCorte1234.SetActive(true);
                        num = 1234;
                    }
                    if (num == 235)
                    {
                        ZanahoriaCorte235.gameObject.SetActive(false);
                        ZanahoriaCorte1235.SetActive(true);
                        num = 1235;
                    }
                    if (num == 236)
                    {
                        ZanahoriaCorte236.gameObject.SetActive(false);
                        ZanahoriaCorte1236.SetActive(true);
                        num = 1236;
                    }
                    if (num == 245)
                    {
                        ZanahoriaCorte245.gameObject.SetActive(false);
                        ZanahoriaCorte1245.SetActive(true);
                        num = 1245;
                    }
                    if (num == 246)
                    {
                        ZanahoriaCorte246.gameObject.SetActive(false);
                        ZanahoriaCorte1246.SetActive(true);
                        num = 1246;
                    }
                    if (num == 256)
                    {
                        ZanahoriaCorte256.gameObject.SetActive(false);
                        ZanahoriaCorte1256.SetActive(true);
                        num = 1256;
                    }
                    if (num == 345)
                    {
                        ZanahoriaCorte345.gameObject.SetActive(false);
                        ZanahoriaCorte1345.SetActive(true);
                        num = 1345;
                    }
                    if (num == 346)
                    {
                        ZanahoriaCorte346.gameObject.SetActive(false);
                        ZanahoriaCorte1346.SetActive(true);
                        num = 1346;
                    }
                    if (num == 356)
                    {
                        ZanahoriaCorte356.gameObject.SetActive(false);
                        ZanahoriaCorte1356.SetActive(true);
                        num = 1356;
                    }
                    if (num == 456)
                    {
                        ZanahoriaCorte456.gameObject.SetActive(false);
                        ZanahoriaCorte1456.SetActive(true);
                        num = 1456;
                    }
                }
                if (_zona == dos) //Corte num 1
                {
                    if (num == 134)
                    {
                        ZanahoriaCorte134.gameObject.SetActive(false);
                        ZanahoriaCorte1234.SetActive(true);
                        num = 1234;
                    }
                    if (num == 135)
                    {
                        ZanahoriaCorte135.gameObject.SetActive(false);
                        ZanahoriaCorte1235.SetActive(true);
                        num = 1235;
                    }
                    if (num == 136)
                    {
                        ZanahoriaCorte136.gameObject.SetActive(false);
                        ZanahoriaCorte1236.SetActive(true);
                        num = 1236;
                    }
                    if (num == 145)
                    {
                        ZanahoriaCorte145.gameObject.SetActive(false);
                        ZanahoriaCorte1245.SetActive(true);
                        num = 1245;
                    }
                    if (num == 146)
                    {
                        ZanahoriaCorte146.gameObject.SetActive(false);
                        ZanahoriaCorte1246.SetActive(true);
                        num = 1246;
                    }
                    if (num == 156)
                    {
                        ZanahoriaCorte156.gameObject.SetActive(false);
                        ZanahoriaCorte1256.SetActive(true);
                        num = 1256;
                    }
                    if (num == 345)
                    {
                        ZanahoriaCorte345.gameObject.SetActive(false);
                        ZanahoriaCorte2345.SetActive(true);
                        num = 2345;
                    }
                    if (num == 346)
                    {
                        ZanahoriaCorte346.gameObject.SetActive(false);
                        ZanahoriaCorte2346.SetActive(true);
                        num = 2346;
                    }
                    if (num == 356)
                    {
                        ZanahoriaCorte356.gameObject.SetActive(false);
                        ZanahoriaCorte2356.SetActive(true);
                        num = 2356;
                    }
                    if (num == 456)
                    {
                        ZanahoriaCorte456.gameObject.SetActive(false);
                        ZanahoriaCorte2456.SetActive(true);
                        num = 2456;
                    }
                }
                if (_zona == tres) //Corte num 3
                {
                    if (num == 124)
                    {
                        ZanahoriaCorte124.gameObject.SetActive(false);
                        ZanahoriaCorte1234.SetActive(true);
                        num = 1234;
                    }
                    if (num == 125)
                    {
                        ZanahoriaCorte125.gameObject.SetActive(false);
                        ZanahoriaCorte1235.SetActive(true);
                        num = 1235;
                    }
                    if (num == 126)
                    {
                        ZanahoriaCorte126.gameObject.SetActive(false);
                        ZanahoriaCorte1236.SetActive(true);
                        num = 1236;
                    }
                    if (num == 145)
                    {
                        ZanahoriaCorte145.gameObject.SetActive(false);
                        ZanahoriaCorte1345.SetActive(true);
                        num = 1345;
                    }
                    if (num == 146)
                    {
                        ZanahoriaCorte146.gameObject.SetActive(false);
                        ZanahoriaCorte1346.SetActive(true);
                        num = 1346;
                    }
                    if (num == 156)
                    {
                        ZanahoriaCorte156.gameObject.SetActive(false);
                        ZanahoriaCorte1356.SetActive(true);
                        num = 1356;
                    }
                    if (num == 245)
                    {
                        ZanahoriaCorte245.gameObject.SetActive(false);
                        ZanahoriaCorte2345.SetActive(true);
                        num = 2345;
                    }
                    if (num == 246)
                    {
                        ZanahoriaCorte246.gameObject.SetActive(false);
                        ZanahoriaCorte2346.SetActive(true);
                        num = 2346;
                    }
                    if (num == 256)
                    {
                        ZanahoriaCorte256.gameObject.SetActive(false);
                        ZanahoriaCorte2356.SetActive(true);
                        num = 2356;
                    }
                    if (num == 456)
                    {
                        ZanahoriaCorte456.gameObject.SetActive(false);
                        ZanahoriaCorte3456.SetActive(true);
                        num = 3456;
                    }
                }
                if (_zona == cuatro) //Corte num 4
                {
                    if (num == 123)
                    {
                        ZanahoriaCorte123.gameObject.SetActive(false);
                        ZanahoriaCorte1234.SetActive(true);
                        num = 1234;
                    }
                    if (num == 125)
                    {
                        ZanahoriaCorte125.gameObject.SetActive(false);
                        ZanahoriaCorte1245.SetActive(true);
                        num = 1245;
                    }
                    if (num == 126)
                    {
                        ZanahoriaCorte126.gameObject.SetActive(false);
                        ZanahoriaCorte1246.SetActive(true);
                        num = 1246;
                    }
                    if (num == 135)
                    {
                        ZanahoriaCorte135.gameObject.SetActive(false);
                        ZanahoriaCorte1345.SetActive(true);
                        num = 1345;
                    }
                    if (num == 136)
                    {
                        ZanahoriaCorte136.gameObject.SetActive(false);
                        ZanahoriaCorte1346.SetActive(true);
                        num = 1346;
                    }
                    if (num == 156)
                    {
                        ZanahoriaCorte156.gameObject.SetActive(false);
                        ZanahoriaCorte1456.SetActive(true);
                        num = 1456;
                    }
                    if (num == 235)
                    {
                        ZanahoriaCorte235.gameObject.SetActive(false);
                        ZanahoriaCorte2345.SetActive(true);
                        num = 2345;
                    }
                    if (num == 236)
                    {
                        ZanahoriaCorte236.gameObject.SetActive(false);
                        ZanahoriaCorte2346.SetActive(true);
                        num = 2346;
                    }
                    if (num == 356)
                    {
                        ZanahoriaCorte356.gameObject.SetActive(false);
                        ZanahoriaCorte3456.SetActive(true);
                        num = 3456;
                    }
                }
                if (_zona == cinco) //Corte num 5
                {
                    if (num == 123)
                    {
                        ZanahoriaCorte123.gameObject.SetActive(false);
                        ZanahoriaCorte1235.SetActive(true);
                        num = 1235;
                    }
                    if (num == 124)
                    {
                        ZanahoriaCorte124.gameObject.SetActive(false);
                        ZanahoriaCorte1245.SetActive(true);
                        num = 1245;
                    }
                    if (num == 126)
                    {
                        ZanahoriaCorte126.gameObject.SetActive(false);
                        ZanahoriaCorte1256.SetActive(true);
                        num = 1256;
                    }
                    if (num == 134)
                    {
                        ZanahoriaCorte134.gameObject.SetActive(false);
                        ZanahoriaCorte1345.SetActive(true);
                        num = 1345;
                    }
                    if (num == 136)
                    {
                        ZanahoriaCorte136.gameObject.SetActive(false);
                        ZanahoriaCorte1356.SetActive(true);
                        num = 1356;
                    }
                    if (num == 146)
                    {
                        ZanahoriaCorte146.gameObject.SetActive(false);
                        ZanahoriaCorte1456.SetActive(true);
                        num = 1456;
                    }
                    if (num == 236)
                    {
                        ZanahoriaCorte236.gameObject.SetActive(false);
                        ZanahoriaCorte2356.SetActive(true);
                        num = 2356;
                    }
                    if (num == 246)
                    {
                        ZanahoriaCorte246.gameObject.SetActive(false);
                        ZanahoriaCorte2456.SetActive(true);
                        num = 2456;
                    }
                    if (num == 346)
                    {
                        ZanahoriaCorte346.gameObject.SetActive(false);
                        ZanahoriaCorte3456.SetActive(true);
                        num = 3456;
                    }
                }
                if (_zona == seis) //Corte num 6
                {
                    if (num == 123)
                    {
                        ZanahoriaCorte123.gameObject.SetActive(false);
                        ZanahoriaCorte1236.SetActive(true);
                        num = 1236;
                    }
                    if (num == 124)
                    {
                        ZanahoriaCorte124.gameObject.SetActive(false);
                        ZanahoriaCorte1246.SetActive(true);
                        num = 1246;
                    }
                    if (num == 125)
                    {
                        ZanahoriaCorte125.gameObject.SetActive(false);
                        ZanahoriaCorte1256.SetActive(true);
                        num = 1256;
                    }
                    if (num == 134)
                    {
                        ZanahoriaCorte134.gameObject.SetActive(false);
                        ZanahoriaCorte1346.SetActive(true);
                        num = 1346;
                    }
                    if (num == 135)
                    {
                        ZanahoriaCorte135.gameObject.SetActive(false);
                        ZanahoriaCorte1356.SetActive(true);
                        num = 1356;
                    }
                    if (num == 145)
                    {
                        ZanahoriaCorte145.gameObject.SetActive(false);
                        ZanahoriaCorte1456.SetActive(true);
                        num = 1456;
                    }
                    if (num == 234)
                    {
                        ZanahoriaCorte234.gameObject.SetActive(false);
                        ZanahoriaCorte2346.SetActive(true);
                        num = 2346;
                    }
                    if (num == 235)
                    {
                        ZanahoriaCorte235.gameObject.SetActive(false);
                        ZanahoriaCorte2356.SetActive(true);
                        num = 2356;
                    }
                    if (num == 245)
                    {
                        ZanahoriaCorte245.gameObject.SetActive(false);
                        ZanahoriaCorte2456.SetActive(true);
                        num = 2456;
                    }
                    if (num == 345)
                    {
                        ZanahoriaCorte345.gameObject.SetActive(false);
                        ZanahoriaCorte3456.SetActive(true);
                        num = 3456;
                    }
                }
            }
            if (ganar == 5)
            {
                if (_zona == uno) //Corte num 1
                {
                    if (num == 2345)
                    {
                        ZanahoriaCorte2345.gameObject.SetActive(false);
                        ZanahoriaCorte12345.SetActive(true);
                    }
                    if (num == 2346)
                    {
                        ZanahoriaCorte2346.gameObject.SetActive(false);
                        ZanahoriaCorte12346.SetActive(true);
                    }
                    if (num == 2356)
                    {
                        ZanahoriaCorte2356.gameObject.SetActive(false);
                        ZanahoriaCorte12356.SetActive(true);
                    }
                    if (num == 2456)
                    {
                        ZanahoriaCorte1256.gameObject.SetActive(false);
                        ZanahoriaCorte12456.SetActive(true);
                    }
                    if (num == 3456)
                    {
                        ZanahoriaCorte3456.gameObject.SetActive(false);
                        ZanahoriaCorte13456.SetActive(true);
                    }
                }
                if (_zona == dos) //Corte num 2
                {
                    if (num == 1345)
                    {
                        ZanahoriaCorte1345.gameObject.SetActive(false);
                        ZanahoriaCorte12345.SetActive(true);
                    }
                    if (num == 1346)
                    {
                        ZanahoriaCorte1346.gameObject.SetActive(false);
                        ZanahoriaCorte12346.SetActive(true);
                    }
                    if (num == 1356)
                    {
                        ZanahoriaCorte1236.gameObject.SetActive(false);
                        ZanahoriaCorte12356.SetActive(true);
                    }
                    if (num == 1456)
                    {
                        ZanahoriaCorte1456.gameObject.SetActive(false);
                        ZanahoriaCorte12456.SetActive(true);
                    }
                    if (num == 3456)
                    {
                        ZanahoriaCorte3456.gameObject.SetActive(false);
                        ZanahoriaCorte23456.SetActive(true);
                    }
                }
                if (_zona == tres) //Corte num 3
                {
                    if (num == 1245)
                    {
                        ZanahoriaCorte1245.gameObject.SetActive(false);
                        ZanahoriaCorte12345.SetActive(true);
                    }
                    if (num == 1246)
                    {
                        ZanahoriaCorte1246.gameObject.SetActive(false);
                        ZanahoriaCorte12346.SetActive(true);
                    }
                    if (num == 1256)
                    {
                        ZanahoriaCorte1236.gameObject.SetActive(false);
                        ZanahoriaCorte12356.SetActive(true);
                    }
                    if (num == 1356)
                    {
                        ZanahoriaCorte1356.gameObject.SetActive(false);
                        ZanahoriaCorte13456.SetActive(true);
                    }
                    if (num == 2456)
                    {
                        ZanahoriaCorte2456.gameObject.SetActive(false);
                        ZanahoriaCorte23456.SetActive(true);
                    }
                }
                if (_zona == cuatro) //Corte num 4
                {
                    if (num == 1235)
                    {
                        ZanahoriaCorte1235.gameObject.SetActive(false);
                        ZanahoriaCorte12345.SetActive(true);
                    }
                    if (num == 1236)
                    {
                        ZanahoriaCorte1236.gameObject.SetActive(false);
                        ZanahoriaCorte12346.SetActive(true);
                    }
                    if (num == 1256)
                    {
                        ZanahoriaCorte1256.gameObject.SetActive(false);
                        ZanahoriaCorte12456.SetActive(true);
                    }
                    if (num == 1356)
                    {
                        ZanahoriaCorte1356.gameObject.SetActive(false);
                        ZanahoriaCorte13456.SetActive(true);
                    }
                    if (num == 2356)
                    {
                        ZanahoriaCorte2356.gameObject.SetActive(false);
                        ZanahoriaCorte23456.SetActive(true);
                    }
                }
                if (_zona == cinco) //Corte num 4
                {
                    if (num == 1234)
                    {
                        ZanahoriaCorte1234.gameObject.SetActive(false);
                        ZanahoriaCorte12345.SetActive(true);
                    }
                    if (num == 1236)
                    {
                        ZanahoriaCorte1236.gameObject.SetActive(false);
                        ZanahoriaCorte12356.SetActive(true);
                    }
                    if (num == 1246)
                    {
                        ZanahoriaCorte1246.gameObject.SetActive(false);
                        ZanahoriaCorte12456.SetActive(true);
                    }
                    if (num == 1346)
                    {
                        ZanahoriaCorte1346.gameObject.SetActive(false);
                        ZanahoriaCorte13456.SetActive(true);
                    }
                    if (num == 2346)
                    {
                        ZanahoriaCorte2346.gameObject.SetActive(false);
                        ZanahoriaCorte23456.SetActive(true);
                    }
                }
                if (_zona == seis) //Corte num 6
                {
                    if (num == 1234)
                    {
                        ZanahoriaCorte1234.gameObject.SetActive(false);
                        ZanahoriaCorte12346.SetActive(true);
                    }
                    if (num == 1245)
                    {
                        ZanahoriaCorte1245.gameObject.SetActive(false);
                        ZanahoriaCorte12456.SetActive(true);
                    }
                    if (num == 1235)
                    {
                        ZanahoriaCorte1235.gameObject.SetActive(false);
                        ZanahoriaCorte12356.SetActive(true);
                    }
                    if (num == 1345)
                    {
                        ZanahoriaCorte1345.gameObject.SetActive(false);
                        ZanahoriaCorte13456.SetActive(true);
                    }
                    if (num == 2345)
                    {
                        ZanahoriaCorte2345.gameObject.SetActive(false);
                        ZanahoriaCorte23456.SetActive(true);
                    }
                }
            }
            
            if (ganar >= 6)
            {
                //No sale el canvas de ganar porque estas viriables no estan asignadas a ningun objeto
                ZanahoriaCorte12345.SetActive(false);
                ZanahoriaCorte12346.SetActive(false);
                ZanahoriaCorte12356.SetActive(false);
                ZanahoriaCorte13456.SetActive(false);
                ZanahoriaCorte23456.SetActive(false);
                ZanahoriaCorte12456.SetActive(false);
                ZanahoriaConCortes.SetActive(true);
                Destroy(GameObject.FindGameObjectWithTag(_zona));
                _zona = string.Empty;
                Tiempo();
                Ganaste();
            }
            Destroy(GameObject.FindGameObjectWithTag(_zona));
            _zona = string.Empty;
            //Debug.Log("Acertaste");
        }
        else
        {
            vidas--;
            //Debug.Log("Fallaste");
            if (vidas <= 0)
            {
                Morir();
            }
        }
    }
    public void Morir()
    {
        if (vidas <= 0)
        {
            canvasGameOver.SetActive(true);
            Boton.gameObject.SetActive(false);
        }
    }
    public void Ganaste()
    {
        canvasWinGame.SetActive(true);
        Boton.gameObject.SetActive(false);
        //Los sonidos de victoria
        StartCoroutine(GameManager.Instance.MusicaStopTimer(2.088f));
        GameManager.Instance.SonidoStop();
        GameManager.Instance.SonidoPlay(13);
    }
    IEnumerable Tiempo()
    {
        yield return new WaitForSeconds(3);
    }
}
