

// using UnityEngine;
// using UnityEngine.InputSystem;

// public class PurlyMovement : MonoBehaviour
// {
//     [SerializeField] private float speed = 5.0f;
//     [SerializeField] private float rotationSpeed = 300.0f;

//     void Update()
//     {
//         // Movement (WASD + Arrow Keys)
//         if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
//         {
//             transform.localPosition += new Vector3(0f, speed * Time.deltaTime, 0f);
//         }

//         if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
//         {
//             transform.localPosition += new Vector3(0f, -speed * Time.deltaTime, 0f);
//         }

//         if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
//         {
//             transform.localPosition += new Vector3(speed * Time.deltaTime, 0f, 0f);
//         }

//         if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
//         {
//             transform.localPosition += new Vector3(-speed * Time.deltaTime, 0f, 0f);
//         }

//        // Rotation (Q/E)
//         if (Input.GetKey(KeyCode.Q))
//         {
//             transform.Find("Bottom").Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
//         }

//         if (Input.GetKey(KeyCode.E))
//         {
//             transform.Find("Bottom").Rotate(0f, -rotationSpeed * Time.deltaTime, 0f);
//         }
//     }   
// }



using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PurlyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f; // faster now
    [SerializeField] private float rotationSpeed = 300.0f;

    Rigidbody2D purly;
    GameObject wall;

    void Start()
    {
        purly = GetComponent<Rigidbody2D>();
        wall = GameObject.Find("wall");
    }

    void Update()
    {
        // Movement (WASD + Arrow Keys)

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) // FIXED ||
        {
            purly.MovePosition(transform.position + new Vector3(0f, speed * Time.deltaTime, 0f)); // FIXED
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) // FIXED ||
        {
            purly.MovePosition(transform.position + new Vector3(0f, -speed * Time.deltaTime, 0f));
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // FIXED ||
        {
            purly.MovePosition(transform.position + new Vector3(speed * Time.deltaTime, 0f, 0f));
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // FIXED ||
        {
            purly.MovePosition(transform.position + new Vector3(-speed * Time.deltaTime, 0f, 0f));
        }

        // Rotation (Q/E)
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Find("Bottom").Rotate(0f, 0f, rotationSpeed * Time.deltaTime); // FIXED name + axis
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Find("Bottom").Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("balloonTag"))
        {
            Destroy(collision.gameObject);
        }
    }
}