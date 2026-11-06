using UnityEngine;

public class movement : MonoBehaviour
{
    public float collectDist = 35f;
    public float moveSpeed = 5f;
    private Transform player;
    private bool moveTowards = false;
    
    void Start(){
    	player = Camera.main.transform;
    }
    
    void Update(){
    	if (moveTowards){
    		transform.position = Vector3.MoveTowards(
    			transform.position,
    			player.position,
    			moveSpeed * Time.deltaTime);
    		}
    }
    
    public void OnPointerEnter(){

    	float distance = Vector3.Distance(transform.position, player.position);
    	if (distance < collectDist){
        	Destroy(gameObject);}
    }
    
    public void OnPointerExit(){}

	public void OnPointerClick(){}
    
    public void AttractToPlayer(){
    	moveTowards = true;
    }
}
