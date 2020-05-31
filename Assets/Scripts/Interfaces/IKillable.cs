/* Will be used to determine if an object can be killed in the scene, this is useful if something can 
 * take damage but not necessarily be killed, such as a wall.
 */

using System.Collections;

public interface IKillable 
{
    IEnumerator Kill();
}
