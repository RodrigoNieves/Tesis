fFacilidad <- 1.25
x <- seq(from=0, to = 6, by = 0.1)
y <- exp(-1*fFacilidad*x)

df <- data.frame(x,y)

g <- ggplot(data= df, aes(x=x,y=y))
g <- g + geom_line()
g <- g + scale_x_continuous(breaks=seq(from=0,to=6,by=1))
g <- g + xlab("Diferencia en dificultad")
g <- g + ylab("Factor para incremento")
g <- g + ggtitle("Factor de incremento(fFacilidad = 1.25)")
print(g)