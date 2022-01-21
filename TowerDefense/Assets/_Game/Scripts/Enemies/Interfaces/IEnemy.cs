using Game.Towers.Projectiles.Enums;

namespace Game.Enemies.Interfaces
{
    public interface IEnemy
    {
        void Damage(float damage, ProjectileEffect projectileEffect);
    }
}
