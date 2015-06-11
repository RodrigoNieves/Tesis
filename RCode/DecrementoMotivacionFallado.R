aNegativa <- 0.25
x <- seq(from=0, to = 6, by = 0.1)
y <- aNegativa * exp(-1*aNegativa*x)

df <- data.frame(x,y)

g <- ggplot(data= df, aes(x=x,y=y))
g <- g + geom_line()
g <- g + scale_x_continuous(breaks=seq(from=0,to=6,by=1))
g <- g + xlab("problemas previamente fallados")
g <- g + ylab("Decremento en motivación")
g <- g + ggtitle("Decrementos en motivación(aNegativa = 0.25)")
print(g)