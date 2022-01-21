using Game.Towers.Projectiles.Enums;

namespace Game.Enemies.Interfaces
{
    // This is just an interface to take damage
    public interface IEnemy
    {
        void Damage(float damage, ProjectileEffect projectileEffect);
    }
}
