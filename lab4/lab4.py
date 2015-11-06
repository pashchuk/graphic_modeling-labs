import matplotlib.pyplot as plt
import matplotlib.gridspec as gridspec
import numpy as np

fig = plt.figure()
box = dict(facecolor='yellow', pad=5, alpha=0.2)

X = np.arange(-8.8857,8.8857,0.01)
Y = np.arange(-8.8857,8.8857,0.01)
Z = np.sin(np.sqrt(X**2 + Y**2))

gs = gridspec.GridSpec(4, 2)
linear = fig.add_subplot(gs[0,:])
hist = fig.add_subplot(gs[1,:])
pie = fig.add_subplot(gs[2:,:])

with plt.style.context('fivethirtyeight'):
    linear.plot(Y, Z)
    linear.set_title('Z(x)')
    linear.set_ylabel('Z')
    linear.set_ylim(-1.2, 1.2)

hist.hist(Z, bins=50, normed=1, color='green')
hist.set_title('Z(x)')
hist.set_ylabel('Z')

labels = '-1 : -0.5', '-0.5 : -0.1', '-0.1 : 0.1', '0.1 : 1'
colors = ['yellowgreen', 'gold', 'lightskyblue', 'lightcoral']
explode = (0.1, 0, 0, 0) 
sizes = [100*len([x for x in Z if x <= -0.5])/float(len(Z)),
         100*len([x for x in Z if x > -0.5 and x <= -0.1 ])/float(len(Z)),
         100*len([x for x in Z if x > -0.1 and x <= 0.1])/float(len(Z)),
         100*len([x for x in Z if x > 0.1])/float(len(Z))]
pie.pie(sizes, explode=explode, labels=labels, colors=colors,
        autopct='%1.1f%%', shadow=True, startangle=90)

plt.show()