using System;

public class Noeud
{
    // la classe noeud represente un membre du club de karate
    public int Id
    {
        get; set; // numero du membre
    }
    public List<Noeud> Voisins
    {
        get;set; // Liste des membres connectes
    }
    public Noeud(int id)
	{
        Id = id;
        Voisins = new List<Noeud>(); // Initialisation de la liste des voisins
	}
    public void AjouterVoisin(Noeud voisin)
    {
        if (!Voisin.Contains(voisin)) // eviter d'ajouter deux fois la mm personne
        {
            voisin.Add(voisin);
            voisin.Voisins.Add(this);// ajoute aussi dans l'autre sens
        }
    }
    public override string ToString()
    {
        return $"Membre {Id}";
    } 
}
