# PokeLearn

![Screenshot PokeLearn](https://alvaro4mg.vercel.app/images/PokeLearn/pokelearn.png)

Hi, I'm **Álvaro**, a Game Developer from Spain. You can check out my online portfolio [here](https://alvaro4mg.vercel.app/).

This is PokeLearn, a Pokemon-themed quiz game designed to support English learning in Spanish educational centers.

Check out its current state on itch.io [here](https://alvaro4mg.itch.io/pokelearn).


## Local Version
The local version allows you to enter your own questions manually with a simple txt file.

The format is as follows:
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

> Example 1:

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
