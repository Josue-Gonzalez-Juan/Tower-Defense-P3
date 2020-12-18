using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public Waypoint currentDestination;
  public WaypointManager waypointManager;
  public PurseManager purseManager;
  private int currentIndexWaypoint = 0;
  public float speed = 1;
  public int deathWorth;
  public int maxHealth;
  public int currentHealth;
  public Transform healthBar;

  public AudioSource death;

  public void Initialize(WaypointManager waypointManager, PurseManager purseManager)
  {
    this.waypointManager = waypointManager;
    this.purseManager = purseManager;
    GetNextWaypoint();
    transform.position = currentDestination.transform.position; // Move to WP0
    GetNextWaypoint();
  }

  void Update()
  {
    Vector3 direction = currentDestination.transform.position - transform.position;
    if (direction.magnitude < .2f)
    {
      GetNextWaypoint();
    }
    transform.Translate(direction.normalized * speed * Time.deltaTime);
  }

  private void GetNextWaypoint()
  {
    currentDestination = waypointManager.GetNeWaypoint(currentIndexWaypoint);
    currentIndexWaypoint++;
  }

  public void takeDamage(int damage)
  {
    currentHealth += -damage;
    float damagePercent = (float)currentHealth / (float)maxHealth;
    healthBar.localScale = new Vector3(damagePercent, 1f);
    if (currentHealth <= 0)
    {
       Death();
    }
  }

    public void Death()
    {
        death.Play();
        purseManager.coins += deathWorth;
        Destroy(gameObject);
    }
}
