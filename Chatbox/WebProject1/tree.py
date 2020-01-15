# -*- coding: utf-8 -*-
import yaml
TREE = yaml.load("""
say: "Select your favorite movie genre? (options: horror, comedy, drama)"
answers:
  horror:
    say: Would you like to watch a foreign movie or a hollywood movie?
    answers:
      foreign:
       say: Might I suggest A Tale of Two Sisters. With 22 wins and 2 nominations , Sisters became the highest-grossing Korean horror film and the first to screen in the U.S., where it was remade in 2009 as The Uninvited starring Emily Browning and Elizabeth Banks.
      hollywood:
       say: Might I suggest Heriditary. With 29 wins and 77 nominations , was acclaimed by critics, with Collette's performance receiving particular praise, and was a commercial success    
  comedy:
    say: Would you like to watch a Spoof  or a Romedy?
    answers:
      Spoof:
       say: In the Monty Python and the Holy Grail King Arthur and his Knights of the Round Table embark on a surreal, low-budget search for the Holy Grail, encountering many, very silly obstacles.
      Romedy:
        say: I am sure you will love Little Manhattan. A heart warming story of A 10-year-old boy and an 11-year-old girl who find love in New York City
  drama:
    say: Would you like to watch a foreign movie or a hollywood movie?
    answers:
      foreign:
       say: Might I suggest The Girl Who Leapt Through Time a.k.a Toki o kakeru shôjo.A high-school girl named Makoto acquires the power to travel back in time, and decides to use it for her own personal benefits. Little does she know that she is affecting the lives of others just as much as she is her own.
      hollywood:
       say: The Help is a 2011 American period drama film written and directed by Tate Taylor and adapted from Kathryn Stocketts 2009 novel of the same name. 
""")
