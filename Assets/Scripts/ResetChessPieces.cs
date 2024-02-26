using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetChessPieces : MonoBehaviour
{

    [System.Serializable]
    public class ChessPieceData
    {
        public Vector3 InitialPos;
        public Transform ChestPiece;
    }

    public List<ChessPieceData> Pieces;

    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider != null && hit.collider.transform == transform)
                {
                    resetChessBoard();
                }
            }
        }
    }

    public void resetChessBoard()
    {
        Debug.Log("made it here6");
        foreach(var piece in Pieces)
        {
            piece.ChestPiece.transform.position = piece.InitialPos;
            if(piece.ChestPiece.name.Contains("Black"))
            {
                piece.ChestPiece.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            else
            {
                piece.ChestPiece.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
        }
    }
}
