using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using YG;

public class Planet : MonoBehaviour
{
    public GameObject prefNumber;
    public int castValue;
    public Transform sun;
    public float orbitalSpeed;
    public float speedPlanet;
    public float scaleSpeed = 0.5f;
    public Stats stats;
    public MenegerUI menegerUI;

    public Planet[] planets;

    public int speedMine;
    public int speedCloud;

    public int mine;
    public int cloud;
    public int bankMax;
    public int countShip;
    public int cloudShipNow;
    public int cloudShipNeed;
    public string namePlanet;

    public bool isCurrent;
    public float orbitRadius; // радиус орбиты, известен заранее
    public float radius;
    public bool isSun;
    public int idPlanet;
    public bool isActive;
    public bool[] isSpawn;

    private SpawnerSpaceShip spawnerSpaceShip;
    public float timerMine;
    private float timerCloud;
    private float timerSpawn;

    public float scaleUpFactor = 1.2f; // на сколько увеличить
    public float duration = 0.1f;      // время увеличения и уменьшения

    private Coroutine scaleCoroutine;
    private Vector3 originalScale;
    public Sprite[] iconeClick;
    public GameObject prefClick;

    void Start()
    {
        originalScale = transform.localScale;
        spawnerSpaceShip = GetComponent<SpawnerSpaceShip>();
        if (isSun) return;
        PlacePlanetOnOrbit();
    }

    void PlacePlanetOnOrbit()
    {
        // Выбираем случайный угол
        float angle = Random.Range(0f, 2 * Mathf.PI);

        // Вычисляем позицию по полярным координатам
        float x = Mathf.Cos(angle) * orbitRadius;
        float y = Mathf.Sin(angle) * orbitRadius;

        // Устанавливаем позицию планеты
        transform.position = new Vector3(x, y, transform.position.z);
    }

    void Update()
    {
        if (isActive)
        {
            if(idPlanet != 7)
            {
                if (YG2.saves.bankNow[idPlanet] != YG2.saves.countBuffs3[idPlanet])      //майнинг
                {
                    timerMine += Time.deltaTime;

                    if (timerMine >= 0.2f)
                    //if (timerMine >= Parametrs.SpeedMine(idPlanet))
                    {
                        timerMine = 0f;
                        YG2.saves.bankNow[idPlanet] += Parametrs.CloudMine(idPlanet);
                        if (YG2.saves.bankNow[idPlanet] >= YG2.saves.countBuffs1[idPlanet] * Parametrs.CloudShip(idPlanet))
                        {
                            YG2.saves.bankNow[idPlanet] = YG2.saves.countBuffs1[idPlanet] * Parametrs.CloudShip(idPlanet);
                        }
                    }
                }
            }
            else
            {
                timerMine += Time.deltaTime;
                if (timerMine >= Parametrs.SpeedMine(idPlanet))
                //if (timerMine >= 1)
                {
                    timerMine = 0f;
                    menegerUI.PrintOre(0);
                }
            }

            //if (countShip != 0)
            //{
            //    timerCloud += Time.deltaTime;

            //    if (timerCloud >= speedCloud)
            //    {
            //        timerCloud = 0f;
            //        cloudShipNow += cloud;
            //        if (cloudShipNow >= cloudShipNeed)
            //        {
            //            cloudShipNow = 0;
            //            countShip--;
            //            spawnerSpaceShip.SpawnShip(10, idPlanet);
            //        }
            //    }
            //}
            if (idPlanet == 7)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (isSpawn[i] && planets[i].isActive && YG2.saves.countBuffs5[i] > YG2.saves.shipFly[i] + YG2.saves.countShip[i])
                    {
                        isSpawn[i] = false;
                        YG2.saves.shipFly[i]++;
                        StartCoroutine(TimerCoroutine(i, i));
                    }
                }
            }
            else
            {
                if (YG2.saves.countShip[idPlanet] != 0 && YG2.saves.bankNow[idPlanet] >= YG2.saves.countBuffs5[idPlanet])
                {
                    YG2.saves.bankNow[idPlanet] -= YG2.saves.countBuffs5[idPlanet];
                    YG2.saves.shipFly[idPlanet]++;
                    YG2.saves.countShip[idPlanet]--;
                    spawnerSpaceShip.SpawnShip(7, idPlanet);
                }
            }
        }
        if (isSun) return;
        transform.RotateAround(sun.position, Vector3.forward, orbitalSpeed * Time.deltaTime * scaleSpeed * speedPlanet);

        transform.rotation = Quaternion.identity; 
    }
    IEnumerator TimerCoroutine(int idHome, int idGo)
    {
        yield return new WaitForSeconds(0.3f);
        isSpawn[idGo] = true;
        spawnerSpaceShip.SpawnShip(idHome, idGo);

    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return; // Не обрабатываем, если клик по UI
        }
        menegerUI.sound.PlaySound(1);
        if (isSun) return;
        if (isCurrent && isActive) ClickPlanet();
    }

    public void IsCurrent()
    {
        isCurrent = !isCurrent;
    }

    public void ClickPlanet()
    {
        menegerUI.PrintOreClick(idPlanet == 7 ? 0 : idPlanet + 1);
        StartCoroutine(PlanetClick());
        GameObject click = Instantiate(prefClick, new Vector2(transform.position.x, transform.position.y + 0.15f), Quaternion.identity);
        click.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = iconeClick[YG2.saves.countBuffsClick[idPlanet == 7 ? 0 : idPlanet + 1]];
    }
    IEnumerator PlanetClick()
    {
        yield return new WaitForSeconds(0.1f);
        PlayClickAnimation();

    }

    public void FinishShip()
    {
        countShip++;
    }

    public void PlayClickAnimation()
    {
        if (scaleCoroutine != null)
            StopCoroutine(scaleCoroutine);

        scaleCoroutine = StartCoroutine(ScaleUpDownCoroutine());
    }

    private IEnumerator ScaleUpDownCoroutine()
    {
        Vector3 startScale = transform.localScale;
        Vector3 targetScale = originalScale * scaleUpFactor;
        float t = 0f;

        // Увеличение
        while (t < duration)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startScale, targetScale, t / duration);
            yield return null;
        }

        t = 0f;

        // Уменьшение
        while (t < duration)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.Lerp(targetScale, originalScale, t / duration);
            yield return null;
        }

        transform.localScale = originalScale;
        scaleCoroutine = null;
    }
}
