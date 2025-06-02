Interface takeDamage(){
public DamageTaken();
}

class shieldDamage implements takeDamage(){
	public void damageTaken(){
		if (playerShield > 0)
    		{
        		playerShield--;
       			return;
    		}
	}

}
