using System;

public class Graphe
{
	public Dictionary <int, Noeud> Membres
	{
		get; set; // listes des membres du club
	}
	public Graphe()
	{
		Membres = new Dictionary<int, Noeud> <int,Noeud > ();
	}
	public void AjouterMembre(int id)
	{
		if (!Membres.ContainsKey(id))
		{
			Membres[id] = new Noeud(id);
		}
	}
	public void Ajouterrelation(int id1,int id2)
	{
		if (!Membres.ContainsKey(id1))
		{
			AjouterMembre (id1);
		}
		if (!Membres.ContainsKey(id2))
		{
			AjouterMembre (id2);
		}
		
		Membres[id1].AjouterVoisin(Membres[id2]); // ajoute une relation entre les deux
	}
	public void AfficherGraphe()
	{
		foreach (var membre in Membres.Values)
		{
			Console.Write($"Membre {membre.Id} est en relation avec : ");
			foreach(var voisin in membre.Voisins)
			{
				Console.Write($"{voisin.Id} ");
			}
			Console.WriteLine();
		}
	}
}
