using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    #region Fields
    public float MinSpeed;
    public float MaxSpeed;

    public float currentSpeed;
    private float x, y, z;

    #endregion

    #region Properties


    #endregion

    #region Functions
    void Start()
    {
        SetPositionAndSpeed();
    }

    void Update()
    {
        float amtToMove = currentSpeed * Time.deltaTime;
        transform.Translate(Vector3.down * amtToMove);

        if (transform.position.y <= -5)
        {
            SetPositionAndSpeed();
        }
    }

    public void SetPositionAndSpeed()
    {
        currentSpeed = Random.RandomRange(MinSpeed, MaxSpeed);
        x = Random.RandomRange(-6.0f, 6.0f);
        y = 7.0f;
        z = 0.0f;

        transform.position = new Vector3(x, y, z);
    }

    #endregion
}
