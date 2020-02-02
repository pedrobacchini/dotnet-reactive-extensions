using System;
using System.Reactive.Linq;

namespace EstudosReactiveExtensions
{
    internal static class Program
    {
        private const bool _isPlayable = true;
        private static bool _isSpawnEnemies = true;
        private static int _waveIndex = 0;
        private const int _waveCount = 5;
        private const int _waveEnemyCount = 5;

        private static void Main()
        {
            _isSpawnEnemies = true;
            var observable = Observable.Interval(TimeSpan.FromMilliseconds(1000))
                .Take(_waveEnemyCount)
                .Where(_ => _isPlayable)
                .TimeInterval();


            observable.Subscribe(value =>
            {
                _waveIndex = (_waveIndex + 1) % _waveCount;
                Console.WriteLine(value);
            }, () =>
            {
                _isSpawnEnemies = false;
                Console.WriteLine("Completed");
            });
            observable.Wait();

//            var timeInterval = Observable.Range(0, _waveEnemyCount)
//                .TimeInterval();
//            timeInterval.Subscribe(value => Console.WriteLine(value));
//            timeInterval.Wait();

//            Observable
//                .Range(0, _waveCount + 1)
//                .Select(i => _waveCount - i)
//                .Subscribe(Console.WriteLine);
//            
//            Observable
//                .Range(0, _waveCount + 1)
//                .Subscribe(Console.WriteLine);
        }
    }

    /*
     * private IEnumerator SpawnAllEnemiesInWave(WaveConfig currentWave)
        {
            _isSpawnEnemies = true;
            for (var enemyCount = 0; enemyCount < currentWave.NumberOfEnemies && _isPlayable; enemyCount++)
            {
                var newEnemy = ObjectPooler.SpawnFromPool(EnemyBasePrefabTag, currentWave.WaveWayPoints[0].position,
                    Quaternion.identity).GetComponent<Enemy>();
                newEnemy.StartEnemy(currentWave);
                EnemyRuntimeSet.Add(newEnemy);
                yield return new WaitForSeconds(currentWave.TimeBetweenSpawns);
            }

            _waveIndex = (_waveIndex + 1) % WaveConfigs.Count;
            _isSpawnEnemies = false;
        }
     */
}