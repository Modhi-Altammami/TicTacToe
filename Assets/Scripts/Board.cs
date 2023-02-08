using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Modhi.ticTacToe
{
    public class Board : MonoBehaviour
    {
        private bool isXTurn;
        private int[,] CellArray = new int[3, 3];
        public static Board instance;
        [SerializeField] private GameObject TextAnimation;
        [SerializeField] private TextMeshProUGUI results;
        void Awake()
        {
            if (instance == null) // if instance is not initilized then instance is equal to class
                instance = this;
            else
            {
                Destroy(gameObject);
            }

        }
        void Start()
        {
            isXTurn = true;
        }
        public void changeTurns(GameObject buttonObj, Vector2 position)
        {
            if (isXTurn)
            {
                buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = "X";
                CellArray[(int)position.x, (int)position.y] = -1;
            }
            else
            {
                buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = "O";
                CellArray[(int)position.x, (int)position.y] = 1;
            }

            checkWinSCertainCell((int)position.x, (int)position.y);

            isXTurn = !isXTurn;
        }

        void checkWinSCertainCell(int x, int y)
        {
            //Horizontal
            int total = 0;

            for (int i = 0; i < CellArray.GetLength(0); i++)
            {
                total += CellArray[x, i];
                if (total == CellArray.GetLength(0) || total == -1 * CellArray.GetLength(0))
                {
                    AnnounceWinner(total);
                    return;
                }

            }

            //Vertical
            total = 0;
            for (int i = 0; i < CellArray.GetLength(0); i++)
            {
                total += CellArray[i, y];
                if (total == CellArray.GetLength(0) || total == -1 * CellArray.GetLength(0))
                {
                    AnnounceWinner(total);
                    return;
                }

            }
            //Diagonal
            total = 0;
            if (x == y)
            {
                for (int j = 0; j < CellArray.GetLength(1); j++)
                {
                    total += CellArray[j, j];
                    if (total == CellArray.GetLength(0) || total == -1 * CellArray.GetLength(0))
                    {
                        AnnounceWinner(total);
                        return;

                    }
                }
            }

            //reverse diagonal
            total = 0;
            if (y + x == CellArray.GetLength(0) - 1)
            {
                int count = CellArray.GetLength(1) - 1;
                for (int i = 0; i < CellArray.GetLength(0); i++)
                {
                    total += CellArray[i, count];
                    if (total == CellArray.GetLength(0) || total == -1 * CellArray.GetLength(0))
                    {
                        AnnounceWinner(total);
                        return;
                    }
                    count--;
                }
            }


            //No win
            bool isMove = false;
            for (int i = 0; i < CellArray.GetLength(0); i++)
            {
                for (int j = 0; j < CellArray.GetLength(1); j++)
                {
                    if (CellArray[i, j].Equals(0))
                    {
                        isMove = true;
                    }
                }
            }

            if (!isMove)
            {
                AnnounceWinner(0);
                return;
            }
            isMove = false;

        }
        void AnnounceWinner(int total)
        {
            if (total == CellArray.GetLength(0))
            {
                results.text = "O wins!";
            }
            else if (total == -1 * CellArray.GetLength(0))
            {
                results.text = "X wins!";
            }
            else
            {
                results.text = "Try Again?";
            }
            TextAnimation.SetActive(true);
            LeanTween.scale(TextAnimation, new Vector3(1.3f, 1.3f, 1.3f), 1f).setEase(LeanTweenType.easeOutElastic); ;
            gameObject.SetActive(false);

        }
    }
}
