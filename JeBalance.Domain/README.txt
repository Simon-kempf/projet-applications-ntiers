Ce README a pour but de décrire les choix que nous avons fait au cours de ce projet.

Nous traiterons des 5 projets constituant l'application JeBalance :
	- JeBalance.Domain
	- Les deux API (API et API_Secrete)
	- JeBalance.Infrastructure
	- JeBalance.UI


--------JeBalance.Domain :

Ce projet a pour but de définir tous les éléments métier, notamment les Denonciation, les Personne et les Reponse.

Les choix principaux effectués pour les Personne sont :
	- enum Statut (NONE, SUSPECT ou INFORMATEUR. Il est possible qu'une Personne soit à la fois Suspect et Informateur, mais le cas étant rare, nous avons 	gardé cet enum afin d'identifier les deux Personne au sein d'une Denonciation)
	- booléen estVIP (car toute Personne peut être promue VIP par les ADMIN)
	- booléen estCalomniateur (car toute Personne peut passer CALOMNIATEUR en dénonçant un VIP)
	- enum Role (NONE, ADMINISTRATEUR, FISC : qui défini les accès dans l'application)

Les choix principaux effectués pour les Denonciation sont :
	- enum Delit (NONE, DissimulationDeRevenus ou EvasionFiscale), car un seul délit peut être dénoncé à la fois
	- booléen estTraitee (dès la Denonciation est traitée, le booléen passe à true et le FISC ne peut plus y répondre)

Les choix principaux effectués pour les Reponse sont :
	- enum Type (NONE, REJET ou CONFIRMATION). Cet enum défini la réponse du FISC, si elle est rejetée ou confirmée.


--------API et API_Secrete :


Nous avons fait le choix de créer ces deux API afin de séparer l'activité liée aux Denonciation (création, consultation, liste des non traitées et réponse sont dans l'API, qui sera utilisée par les Informateur et le FISC) et celle liée aux VIP (création, suppression et consultation de la liste des VIP sont dans l'API_Secrete, qui sera utilisée par les ADMINISTRATEUR).


--------JeBalance.Infrastructure


La difficulté liée à cette partie est le stockage des différentes classes en base de données. Notamment, les Personne, les Adresse et les Reponse sont stockées sous forme de chaîne de caractère en base. La classe Extension les sérialise pour le stockage, et les désérialise pour la restitution.