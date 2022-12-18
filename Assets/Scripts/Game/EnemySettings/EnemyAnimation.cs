// using UnityEngine;
//
// namespace Split.Game.EnemySettings
// {
// 	public class EnemyAnimation : MonoBehaviour
// 	{
//
// 		Vector3 rot = Vector3.zero;
// 		float rotSpeed = 40f;
// 		[SerializeField] private Animator _animator;
//
// 		// Use this for initialization
// 		// void Awake()
// 		// {
// 		// 	gameObject.transform.eulerAngles = rot;
// 		// }
//
// 		// Update is called once per frame
// 		void Update()
// 		{
// 			gameObject.transform.eulerAngles = rot;
// 		}
//
// 		public void Walk(bool isWalk)
// 		{
// 			if (Input.GetKey(KeyCode.W))
// 			{
// 				_animator.SetBool("Walk_Anim", isWalk);
// 			}
// 			else if (Input.GetKeyUp(KeyCode.W))
// 			{
// 				_animator.SetBool("Walk_Anim", isWalk);
//
// 			}
// 		}
//
//
// 		public void Roll(bool isRoll)
// 		{
// 			if (_animator.GetBool("Roll_Anim"))
// 			{
// 				_animator.SetBool("Roll_Anim", false);
// 			}
// 			else
// 			{
// 				_animator.SetBool("Roll_Anim", true);
// 			}
// 		}
//
// 		public void Open(bool isOpen)
// 		{
// 			if (Input.GetKeyDown(KeyCode.LeftControl))
// 			{
// 				if (!_animator.GetBool("Open_Anim"))
// 				{
// 					_animator.SetBool("Open_Anim", true);
// 				}
// 				else
// 				{
// 					_animator.SetBool("Open_Anim", false);
// 				}
// 			}
// 		}
// 	}
// }
//         
//  