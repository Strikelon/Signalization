using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Animator _animator;
    private bool _isFacingRight = true;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!_isFacingRight)
            {
                Flip();
                _isFacingRight = true;
            }

            _animator.SetFloat("BearSpeed", _speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetFloat("BearSpeed", 0);
            _animator.Play("Idle");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (_isFacingRight)
            {
                Flip();
                _isFacingRight = false;
            }

            transform.Translate(_speed * Time.deltaTime * (-1), 0, 0);
            _animator.SetFloat("BearSpeed", _speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * (-1), 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _animator.SetFloat("BearSpeed", 0);
            _animator.Play("Idle");
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}