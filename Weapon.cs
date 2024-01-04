using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private float _directionMultiplier;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private float _timeWaitShooting;

    private Transform _shootObject;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWork = enabled;

        while (isWork)
        {
            var direction = (_shootObject.position - transform.position).normalized;
            var bullet = Instantiate(_gameObject, transform.position + direction, Quaternion.identity);

            bullet.GetComponent<Rigidbody>().transform.up = direction;
            bullet.GetComponent<Rigidbody>().velocity = direction * _directionMultiplier;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}