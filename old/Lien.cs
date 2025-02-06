using System;

public class Lien
{
	public Noeud Source
	{
		get; set;
	}
	public Noeud Destination
	{
		get; set;
	}
	public Lien(Noeud source, Noeud destination)
	{
		Source = source;
		Destination = destination;
	}
	public override string ToString()
	{
		return $"{Source.Id} est connecte a {Destination.Id}";
	}

}