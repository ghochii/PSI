using System;
using System.Collections;
using System.Collections.Generic;

class RechercheGraph
{
    /// Pour les graphes pondérés sans coordonnées (pour plus tard)
    public void Dijkstra(int[,] graph, int depart)
    {
        int nbNodes = graph.GetLength(0);

        /// On initialise un tableau de distances pour stocker toutes les distances 
        int[] distances = new int[nbNodes];

        /// On regarde si le node à déjà été exploré
        bool[] dejaExplore = new bool[nbNodes];

        /// On initialise les 2 tableaux précédents 
        for (int i = 0; i < nbNodes; i++)
        {
            distances[i] = int.MaxValue;
            dejaExplore[i] = false;
        }

        /// La distance entre le départ et le départ est de 0
        distances[depart] = 0;

        /// Pour chaque node (sauf celui du départ)
        for (int count = 0; count < nbNodes - 1; count++)
        {

            /// On prend l'index de la plus petite distance
            int indexMinDistance = minimum_distance(distances, dejaExplore, nbNodes);

            /// On marque que le node avec la plus petite distance, a été exploré
            dejaExplore[indexMinDistance] = true;

            Console.WriteLine($"On visite à partir du node {indexMinDistance} : ");

            /// Pour chaque node
            for (int n = 0; n < nbNodes; n++)
            {
                /// On checke :
                ///  - si le node n'est pas déjà exploré
                ///  - si il existe une connection entre le node d'index de la distance minimale et le n-ième node
                ///  - si la distance a été calculé donc pas égale à int.MaxValue (2,147,483,647)
                ///  - si la distance minimale + le poids de l'arrête est inférieure à la distance pondérée du n-ième node

                if (!dejaExplore[n] && graph[indexMinDistance, n] != 0 && distances[indexMinDistance] != int.MaxValue && distances[indexMinDistance] + graph[indexMinDistance, n] < distances[n])
                {
                    Console.WriteLine("Node : " + n);
                    distances[n] = distances[indexMinDistance] + graph[indexMinDistance, n]; /// La distance n-ième est : la somme des distances minimales pour arriver jusqu'au node d'index "indexMinDistance" + le poids de la connexion entre le n-ième node et le node d'index "indexMinDistance"
                }
            }
            Console.WriteLine();

        }

        AfficherSolution(distances, nbNodes);
    }

    public void BFS(int[,] graph, int depart)
    {
        int nbNodes = graph.GetLength(0);

        /// On initialise un tableau de distances pour stocker toutes les distances 
        int[] distances = new int[nbNodes];

        /// On regarde si le node à déjà été exploré
        bool[] dejaExplore = new bool[nbNodes];

        /// On initialise les 2 tableaux précédents 
        for (int i = 0; i < nbNodes; i++)
        {
            distances[i] = int.MaxValue;
            dejaExplore[i] = false;

        }

        /// Le noeud de départ est déjà exploré
        dejaExplore[depart] = true;

        /// La distance entre le départ et le départ est de 0
        distances[depart] = 0;

        Console.WriteLine("On visite à partir du node " + depart + ":");

        /// On gère les nodes à explorer avec queue
        Queue<int> queue = new Queue<int>();
        /// On initialise la queue avec le node de départ
        queue.Enqueue(depart);

        /// Tant qu'il reste des nodes à explorer
        while (queue.Count > 0)
        {
            int enCours = queue.Dequeue();
            Console.Write(enCours + " ");

            /// Pour chaque node
            for (int i = 0; i < nbNodes; i++)
            {
                /// On parcours les noeuds voisins, donc si la valeur est de 1 qu'ils ont pas déja été visité
                if (graph[enCours, i] == 1 && !dejaExplore[i])
                {
                    dejaExplore[i] = true;
                    distances[i] = distances[enCours] + 1; /// On ajoute 1 à la distance car le graphe n'est pas pondéré
                    queue.Enqueue(i); /// On va ajouter le node voisin à la queue
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine();

        AfficherSolution(distances, nbNodes);

    }

    public void DFS(int[,] graph, int depart)
    {
        int nbNodes = graph.GetLength(0);

        /// On initialise un tableau de distances pour stocker toutes les distances 
        int[] distances = new int[nbNodes];

        /// On regarde si le node a déjà été exploré
        bool[] dejaExplore = new bool[nbNodes];

        /// On initialise les deux tableaux précédents 
        for (int i = 0; i < nbNodes; i++)
        {
            distances[i] = int.MaxValue;
            dejaExplore[i] = false;
        }

        /// Le node de départ est déjà exploré
        dejaExplore[depart] = true;

        /// La distance entre le départ et le départ est de 0
        distances[depart] = 0;

        Console.WriteLine("On visite à partir du node " + depart + ":");

        /// On utilise une pile pour gérer les nodes à explorer
        Stack<int> stack = new Stack<int>();
        /// On initialise la pile avec le node de départ
        stack.Push(depart);

        /// Tant que la pile n'est pas vide
        while (stack.Count > 0)
        {
            /// On prend le dernier élément de la pile
            int nodeToVisit = stack.Pop();

            Console.Write(nodeToVisit + " ");

            /// Pour chaque node
            for (int i = 0; i < nbNodes; i++)
            {
                /// On parcours les noeuds voisins, donc si la valeur est de 1 et qu'ils ont déjà pas été visité
                if (graph[nodeToVisit, i] == 1 && !dejaExplore[i])
                {
                    dejaExplore[i] = true;
                    distances[i] = distances[nodeToVisit] + 1; /// MAJ distance
                    stack.Push(i); /// On ajoute le voisin à la pile
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine();

        AfficherSolution(distances, nbNodes);
    }

    private int minimum_distance(int[] distances, bool[] dejaExplore, int nbNodes)
    {
        int min_distance = int.MaxValue; /// On met une valeur très grande pour être sur que la distance sera inférieure
        int min_index = -1; /// Valeur arbitraire qui se fera écraser

        /// Cette boucle sert à trouver la distance minimale dans le tableau en évitant les sommets déjà explorés
        for (int n = 0; n < nbNodes; n++)
        {
            if (dejaExplore[n] == false && distances[n] <= min_distance)
            {
                min_distance = distances[n];
                min_index = n;
            }
        }

        return min_index;
    }

    void AfficherSolution(int[] distances, int nbNodes)
    {
        Console.Write("Node	 Distance " + "depuis le départ\n");
        for (int i = 0; i < nbNodes; i++)
        {
            Console.Write(i + " \t\t " + distances[i] + "\n");
        }
    }

    public static void Main()
    {
        int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                    { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                    { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                    { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                    { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                    { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                    { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                    { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                    { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };

        int[,] graph2 = new int[,] { { 0, 1, 0, 0, 0, 0, 0, 1, 0 },
                                    { 1, 0, 1, 0, 0, 0, 0, 1, 0 },
                                    { 0, 1, 0, 1, 0, 1, 0, 0, 1 },
                                    { 0, 0, 1, 0, 1, 1, 0, 0, 0 },
                                    { 0, 0, 0, 1, 0, 1, 0, 0, 0 },
                                    { 0, 0, 1, 1, 1, 0, 1, 0, 0 },
                                    { 0, 0, 0, 0, 0, 1, 0, 1, 1 },
                                    { 1, 1, 0, 0, 0, 0, 1, 0, 1 },
                                    { 0, 0, 1, 0, 0, 0, 1, 1, 0 } };

        RechercheGraph t = new RechercheGraph();
        Console.WriteLine("Dijkstra : ");
        Console.WriteLine();

        t.Dijkstra(graph, 0);

        Console.WriteLine();

        Console.WriteLine("BFS : ");
        Console.WriteLine();
        t.BFS(graph2, 0);

        Console.WriteLine();

        Console.WriteLine("DFS : ");
        Console.WriteLine();
        t.DFS(graph2, 0);

    }
}

