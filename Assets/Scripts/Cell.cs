using UnityEngine;
namespace Modhi.ticTacToe
{

    public class Cell : MonoBehaviour
    {
        // cell position 
        [SerializeField] private Vector2 position;
        public void sendPosition()
        {
            Board.instance.changeTurns(gameObject, position);
        }
    }
}

