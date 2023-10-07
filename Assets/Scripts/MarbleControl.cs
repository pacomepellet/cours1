using UnityEngine;
using UnityEngine.UI;
public class MarbleControl : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private LayerMask trackLayer;
    public Text txtScoret;
    private int nbScore=0;
    private Rigidbody _rigidbody;
    private Vector3 _trackNormal = Vector3.up;
    private Vector3 _newTrackNormal = Vector3.up;
    private Transform _referenceTransform;
    private float _speedMultiplier = 200;

    public void SetReferenceTransform(Transform reference)
    {
        _referenceTransform = reference;
    }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (Camera.main is { }) _referenceTransform = Camera.main.transform;
    }

    void Update()
    {
        UpdateReference();
        
        Vector3 speedVector = Vector3.zero;
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        if (verticalAxis != 0)
        {
            if (verticalAxis > 0)
                speedVector += _referenceTransform.forward;
            else if (verticalAxis < 0)
                speedVector -= _referenceTransform.forward;
        }
        
        if (horizontalAxis != 0)
        {
            if (horizontalAxis > 0)
                speedVector += _referenceTransform.right;
            else if (horizontalAxis < 0)
                speedVector -= _referenceTransform.right;
        }
        
        var diffNormal = _newTrackNormal - _trackNormal;
        _trackNormal += diffNormal * Time.deltaTime;
        _rigidbody.velocity -= _trackNormal * (Physics2D.gravity.magnitude * Time.deltaTime);

        if (speedVector != Vector3.zero)
            _rigidbody.AddForce(speedVector.normalized * (_speedMultiplier * speed * Time.deltaTime));
    }

    private void OnCollisionStay(Collision other)
    {
        if (trackLayer != (trackLayer | (1 << other.gameObject.layer))) return;
        _newTrackNormal = other.contacts.Length > 0 ? other.contacts[0].normal : Vector3.up;
    }

    private void UpdateReference()
    {
        var forward = _referenceTransform.forward;
        forward -= (forward - _rigidbody.velocity) * Time.deltaTime;
        
        _referenceTransform.LookAt(transform.position + forward, _trackNormal);
    }

    private void OnDrawGizmos()
    {
        if (_referenceTransform == null)
            return;
        
        Debug.DrawRay(_referenceTransform.position, _referenceTransform.forward * 4, Color.green);
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Collectible"))
		{
			nbScore+=5;
			txtScoret.text="Score "+nbScore.ToString();
			Destroy(other.gameObject);
		}
		if (other.CompareTag("20pts"))
		{
			nbScore+=20;
			txtScoret.text="Score "+nbScore.ToString();
			Destroy(other.gameObject);
		}
		if (other.CompareTag("50pts"))
		{
			nbScore+=50;
			txtScoret.text="Score "+nbScore.ToString();
			Destroy(other.gameObject);
	    }
	}
}