'''
This script performs the basic process for applying a machine learning
algorithm to a dataset using Python libraries.

The four steps are:
   1. Download a dataset (using pandas)
   2. Process the numeric data (using numpy)
   3. Train and evaluate learners (using scikit-learn)
   4. Plot and compare results (using matplotlib)


The data is downloaded from URL, which is defined below. As is normal
for machine learning problems, the nature of the source data affects
the entire solution. When you change URL to refer to your own data, you
will need to review the data processing steps to ensure they remain
correct.

============
Example Data
============
The example is from http://mlr.cs.umass.edu/ml/datasets/Spambase
It contains pre-processed metrics, such as the frequency of certain
words and letters, from a collection of emails. A classification for
each one indicating 'spam' or 'not spam' is in the final column.
See the linked page for full details of the data set.

This script uses three classifiers to predict the class of an email
based on the metrics. These are not representative of modern spam
detection systems.
'''

# Remember to update the script for the new data when you change this URL
URL = "http://mlr.cs.umass.edu/ml/machine-learning-databases/spambase/spambase.data"

# Uncomment this call when using matplotlib to generate images
# rather than displaying interactive UI.
#import matplotlib
#matplotlib.use('Agg')

import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import sklearn as ak
try:
    # [OPTIONAL] Seaborn makes plots nicer
    import seaborn as sns
except ImportError:
    pass

# =====================================================================

def download_data():
  
    #frame = df = pd.read_csv("D:\\my data\\test_1.csv",header = 0)
    #frame1 =  pd.read_csv("D:\my data\IndiaVotes_PC__Pune_2014.csv",header = 0)
    #print(frame1.head())
    #frame = df = pd.read_csv("D:\my data\Pune_all_candidates_2014.csv",header = 0)
    #frame1 =  pd.read_csv("D:\my data\IndiaVotes_PC__Pune_2014.csv",header = 0)

    #frame['Candidate Name'] = frame['Candidate Name'].str.lower()
    #frame1['Candidate Name'] = frame1['Candidate Name'].str.lower()
    
   # print(frame1.head())
    #print(frame.head())
    #df_merged = frame.merge(frame1, how='outer', on = 'Candidate Name')
    
    #df_merged = pd.read_csv("D:\my data\merged_2014.csv", encoding='utf-8')
   # df_merged["Position"]=pd.to_numeric(df_merged["Position"])
   # df_merged = df_merged.sort_values('Position')

  # -------------------------------------------------------------------------------------------------------------
    frame_train =pd.read_csv("D:\\train.csv", header = 0)
    frame_test=pd.read_csv("D:\\my data\\test.csv", header =0)
   # -------------------------------------------------------------------------------------------------------------
    sns.set(style="whitegrid", color_codes=True)

    # setting the plot size for all plots
    sns.set(rc={'figure.figsize':(11.7,8.27)})
    frame1 =  pd.read_csv("D:\\my data\\train.csv",header = 0)
  
    xyz =  pd.read_csv("D:\\my data\\Osmanabad\\merged.csv",header = 0)
  
  
    xyz.plot()
    xyz.plot(x = "Criminal Cases",y ="Votes", xticks = range(0,10,1),  kind = "bar")
    graduate_votes = 0
    literate_votes = 0
    high_school_votes =0
    for i , row in frame1.iterrows():
        if "graduate" in row['Education'].lower():
            graduate_votes += pd.to_numeric(row['Votes %'].replace("%",""))
        elif  "pass" in row['Education'].lower(): 
             high_school_votes += pd.to_numeric(row['Votes %'].replace("%",""))
        else:
             literate_votes += pd.to_numeric(row['Votes %'].replace("%",""))

  
    data = {'graduate':[graduate_votes], 'high_school_pass':[high_school_votes],'others':[literate_votes]} 
    df_ = pd.DataFrame(data) 
    
    print(df_.shape)
    df_=df_.astype(float)
    print(df_.head())
    df_.plot( kind="bar")
    #df_.plot(y=["graduate","high_school_pass","others"], kind="bar")
    # Remove the top and down margin
    #sns.despine(offset=10, trim=True)
#-------------------------------------------------------------------------------------------------------------
    from sklearn.naive_bayes import GaussianNB
    outcome_var = ['Result']
    predictor_var = ['MarginWinLabel', 'EducationLabel', 'CriminalCasesLabel', 'PreviousWinsLabel','PartyPopularityLabel','PMProfileLabel']
    #Create a Gaussian Classifier
    model = GaussianNB()
    df = frame_train[predictor_var]
    print(df.head())
    df1 = frame_test[predictor_var]
    print(df1.head())
    target_test = frame_test[outcome_var]
     # Train the model using the training sets
    model.fit(frame_train[predictor_var],frame_train[outcome_var])
    
     #Predict Output
    predicted= model.predict(df1) 
    frame_test['Predicted'] = predicted
    print(frame_test[frame_test['Predicted'] ==0]['Candidate Name'])
    print ("Predicted Value:", predicted)
    #accuracy_score(target_test, predicted, normalize = True)
    return df_merged






if __name__ == '__main__':
    # Download the data set from URL
   
    frame = download_data()
    print(frame.describe())
  
