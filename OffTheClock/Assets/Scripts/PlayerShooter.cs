//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerShooter : MonoBehaviour
//{
//    [SerializeField] private Transform _gunPoint;
//    [SerializeField] private GameObject _bulletTrail;
//    [SerializeField] private float _weaponRange = 10f;
//    [SerializeField] private Animator _muzzleFlashAnimator;


//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        Shoot();
//    }

//    private void Shoot()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            //_muzzleFlashAnimator.SetTrigger("Shoot");

//            var hit = Physics2D.Raycast(
//                _gunPoint.position,
//                transform.up,
//                _weaponRange
//                );

//            var trail = Instantiate(
//                _bulletTrail,
//                _gunPoint.position,
//                transform.rotation
//                );

//            var trailScript = trail.GetComponent<StapleTrail>();

//            if (hit.collider != null)
//            {
//                trailScript.SetTargetPosition(hit.point);
//                var hittable = hit.collider.GetComponent<Enemy>();
//                hittable?.Hit();
//            }
//            else
//            {
//                var endPosition = _gunPoint.position * _weaponRange;
//                trailScript.SetTargetPosition(endPosition);
//            }
//        }
//    }

//}
