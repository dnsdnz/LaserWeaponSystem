# LaserWeaponSystem
Optimized Object Pooling Example

Performance drops when firing the weapon quickly occurs. I tested fropm Profiler values GarbageCollector and my computer started to stutter and overheat and I hear the fan noise too much. 
Cause:
Instantiating and Destroying Objects
We instantiate and destroy laser instances rapidly and it causes performance issues. Instantiating and destroying objects frequently is expensive in terms of memory allocation and garbage collection.
Solution:
Object Pooling is a technique that can help mitigate this issue. Instead of constantly creating and destroying laser instances, you can create a pool of pre-allocated laser objects at the start and reuse them when needed. This reduces the overhead of instantiating and destroying objects and improves performance. This leads to improved performance, especially when firing the gun quickly.

Object pooling is not limited to this lasers system it can be applied to other types of objects in games as well. It's a versatile technique that can help optimize performance in scenarios where objects are frequently created and destroyed.
