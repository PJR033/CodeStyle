using UnityEngine;

public class PathPointsMover : MonoBehaviour
{
    private float _speed;
    private Transform _path;
    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i).GetComponent<Transform>();
        }
    }

    private void Update()
    {
        int currentPointIndex
        var currentPoint = _points[currentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, _speed * Time.deltaTime);

        if (transform.position == currentPoint.position)
        {
            currentPointIndex++;

            if (currentPointIndex == _points.Length)
            {
                currentPointIndex = 0;
            }

            var currentPointPosition = _points[currentPointIndex].transform.position;
            transform.forward = currentPointPosition - transform.position;
        }
    }
}