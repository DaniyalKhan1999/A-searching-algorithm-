# This project of A star searching algorithm is made by the group of students of UIT
Members includes:
Daniyal Khan (17B-014-SE)
Muneeb ullah Khan (17B-050-SE)
Ibad Ahmed (17B-061-SE)

# A-searching-algorithm-
 A* is the most popular choice for pathfinding, because it’s fairly flexible and can be used in a wide range of contexts. A* is like other graph-searching algorithms in that it can potentially search a huge area of the map. It’s like Dijkstra’s algorithm in that it can be used to find a shortest path. It’s like Greedy Best-First-Search in that it can use a heuristic to guide itself. In the simple case, it is as fast as Best-First-Search
# Comparison
 1) One source and One Destination-
→ Use A* Search Algorithm (For Unweighted as well as Weighted Graphs)

2) One Source, All Destination –
→ Use BFS (For Unweighted Graphs)
→ Use Dijkstra (For Weighted Graphs without negative weights)
→ Use Bellman Ford (For Weighted Graphs with negative weights)
# Implementation
Its implementations is similar to Dijsktra’s algorithm.we use a Fibonacci heap to implement the open list instead of a binary heap/self-balancing tree, then the performance will become better (as Fibonacci heap takes O(1) average time to insert into open list and to decrease key)
We will use dynamic programming to reduce the time taken to calculate g
