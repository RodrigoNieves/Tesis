apositiva <- 0.5
 x <- seq(from=0, to = 6, by = 0.1)
 y <- apositiva * exp(-1*apositiva*x)
 
 df <- data.frame(x,y)
 
 g <- ggplot(data= df, aes(x=x,y=y))
 g <- g + geom_line()
 g <- g + scale_x_continuous(breaks=seq(from=0,to=6,by=1))
 g <- g + xlab("problemas previamente resueltos")
 g <- g + ylab("Incremento en motivación")
 g <- g + ggtitle("Incrementos en motivación(aPositiva = 0.5)")
 print(g)