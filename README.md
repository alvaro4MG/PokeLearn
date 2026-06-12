# PokeLearn

![Screenshot PokeLearn](https://alvaro4mg.vercel.app/images/PokeLearn/pokelearn.png)

Hi, I'm **Álvaro**, a Game Developer from Spain. You can check out my online portfolio [here](https://alvaro4mg.vercel.app/).

This is PokeLearn, a Pokemon-themed quiz game designed to support English learning in Spanish educational centers.

Check out its current state on itch.io [here](https://alvaro4mg.itch.io/pokelearn).


## Local Version
The local version allows you to enter your own questions manually with a simple txt file. These txt files can be found and used in the folder of the build PokeLearn_Data/StreamingAssets/Questions. In order to use images and audios for the questions, these must be in the folders Images and Audios, using only the formats .png and .mp3 (more formats coming soon) and in a folder with the same name as the txt filename.

The first lines of the txt file will be as follows:
> =image of the medal (png image in the Badges folder)
> 
> /image of the leader (png image in the Leaders folder)
> 
> $image of the leader's pokemon (png image in the LeaderPokemon folder)




The format of the questions is as follows:
> #Text of question
> 
> %image (optional) // &audio (optional) [ONLY 1 OF THESE]
> 
> @correct answer
> 
> -incorrect answer
> 
> -incorrect answer (optional)
> 
> -incorrect answer (optional)

### Examples of txt files

> Example 1 (including leader information):

=Medalla Inverna.png

/Inverna.png

$Abomasnow Inverna.png

#1. 1 image, 4 answers

%shirt.png

@correct

-incorrect

-incorrect

-incorrect

> Example 2:

#2. 1 image, 2 answers

%shirt.png

@correct

-incorrect

> Example 3:

#3. NO image, 4 answers

@correct

-incorrect

-incorrect

-incorrect


---

## Tech Stack
- **Engine:** Unity  
- **Language:** C#  
- **Platform:** HTML ([itch.io](https://alvaro4mg.itch.io/pokelearn)) and PC (local version)
