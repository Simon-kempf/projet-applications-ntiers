Ce README a pour but de d�crire les choix que nous avons fait au cours de ce projet.

Nous traiterons des 5 projets constituant l'application JeBalance :
	- JeBalance.Domain
	- Les deux API (API et API_Secrete)
	- JeBalance.Infrastructure
	- JeBalance.UI


--------JeBalance.Domain :

Ce projet a pour but de d�finir tous les �l�ments m�tier, notamment les Denonciation, les Personne et les Reponse.

Les choix principaux effectu�s pour les Personne sont :
	- enum Statut (NONE, SUSPECT ou INFORMATEUR. Il est possible qu'une Personne soit � la fois Suspect et Informateur, mais le cas �tant rare, nous avons 	gard� cet enum afin d'identifier les deux Personne au sein d'une Denonciation)
	- bool�en estVIP (car toute Personne peut �tre promue VIP par les ADMIN)
	- bool�en estCalomniateur (car toute Personne peut passer CALOMNIATEUR en d�non�ant un VIP)
	- enum Role (NONE, ADMINISTRATEUR, FISC : qui d�fini les acc�s dans l'application)

Les choix principaux effectu�s pour les Denonciation sont :
	- enum Delit (NONE, DissimulationDeRevenus ou EvasionFiscale), car un seul d�lit peut �tre d�nonc� � la fois
	- bool�en estTraitee (d�s la Denonciation est trait�e, le bool�en passe � true et le FISC ne peut plus y r�pondre)

Les choix principaux effectu�s pour les Reponse sont :
	- enum Type (NONE, REJET ou CONFIRMATION). Cet enum d�fini la r�ponse du FISC, si elle est rejet�e ou confirm�e.


--------API et API_Secrete :


Nous avons fait le choix de cr�er ces deux API afin de s�parer l'activit� li�e aux Denonciation (cr�ation, consultation, liste des non trait�es et r�ponse sont dans l'API, qui sera utilis�e par les Informateur et le FISC) et celle li�e aux VIP (cr�ation, suppression et consultation de la liste des VIP sont dans l'API_Secrete, qui sera utilis�e par les ADMINISTRATEUR).


--------JeBalance.Infrastructure


La difficult� li�e � cette partie est le stockage des diff�rentes classes en base de donn�es. Notamment, les Personne, les Adresse et les Reponse sont stock�es sous forme de cha�ne de caract�re en base. La classe Extension les s�rialise pour le stockage, et les d�s�rialise pour la restitution.