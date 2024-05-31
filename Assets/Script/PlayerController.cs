using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private Tilemap groundTilemap;

    [SerializeField]
    private Tilemap collisionTilemap;

    private PauseMenu pauseMenu;

    private PlayerMovement controls;

    private Dictionary<Vector3Int, GameObject> boxes = new Dictionary<Vector3Int, GameObject>();

    private void Awake()
    {
        controls = new PlayerMovement();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
        controls.main.Newaction.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    private void Move(Vector2 direction)
    {
        Vector3 newPosition = transform.position + (Vector3)direction;
        //Debug.Log($"Trying to move to {newPosition}");

        if (CanMove(direction) && !pauseMenu.IsPaused())
        {
            Collider2D hitCollider = Physics2D.OverlapPoint(newPosition);

            if (hitCollider != null && hitCollider.CompareTag("Pushable"))
            {
                GameObject box = hitCollider.gameObject;
                Vector3 boxNewPosition = box.transform.position + (Vector3)direction;
                //Debug.Log($"Trying to move box to {boxNewPosition}");

                if (CanMoveBox(box, boxNewPosition, direction))
                {
                    //Debug.Log("Box moved.");
                    box.transform.position = boxNewPosition;
                    transform.position = newPosition;
                }
                /*else
                {
                    Debug.Log("Cannot move box.");
                }*/
            }
            else
            {
                //Debug.Log("No box detected, moving player.");
                transform.position = newPosition;
            }
        }
        /*else
        {
            Debug.Log("Cannot move player.");
        }*/
    }

    private bool CanMove(Vector2 direction)
    {
        if (groundTilemap == null || collisionTilemap == null)
        {
            //Debug.LogError("Tilemap reference is null.");
            return false;
        }

        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
        //Debug.Log($"Checking if player can move to {gridPosition}");
        if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition))
        {
            //Debug.Log("Cannot move to the target position.");
            return false;
        }
        return true;
    }

    private bool CanMoveBox(GameObject box, Vector3 boxNewPosition, Vector2 direction)
    {
        if (groundTilemap == null || collisionTilemap == null)
        {
            //Debug.LogError("Tilemap reference is null.");
            return false;
        }

        Vector3Int boxNextGridPosition = groundTilemap.WorldToCell(boxNewPosition);
        //Debug.Log($"Checking if box can move to {boxNextGridPosition}");
        if (!groundTilemap.HasTile(boxNextGridPosition) || collisionTilemap.HasTile(boxNextGridPosition))
        {
            //Debug.Log("Box cannot move to the target position.");
            return false;
        }

        Collider2D[] hitColliders = Physics2D.OverlapPointAll(boxNewPosition);
        int otherBoxesCount = 0;

        foreach (Collider2D collider in hitColliders)
        {
            if (collider != null && collider.CompareTag("Pushable") && collider.gameObject != box)
            {
                otherBoxesCount++;
            }
        }

        Vector3Int nextPosition = groundTilemap.WorldToCell(boxNewPosition + (Vector3)direction);
        if (otherBoxesCount >= 1 && (collisionTilemap.HasTile(nextPosition) || groundTilemap.HasTile(nextPosition)))
        {
            //Debug.Log("Another box blocks the movement.");
            return false;
        }

        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pushable"))
        {
            Vector3Int gridPosition = groundTilemap.WorldToCell(collision.transform.position);
            if (!boxes.ContainsKey(gridPosition))
            {
                boxes[gridPosition] = collision.gameObject;
                //Debug.Log($"Box entered at {gridPosition}");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pushable"))
        {
            Vector3Int gridPosition = groundTilemap.WorldToCell(collision.transform.position);
            if (boxes.ContainsKey(gridPosition))
            {
                boxes.Remove(gridPosition);
                //Debug.Log($"Box exited at {gridPosition}");
            }
        }
    }
}
