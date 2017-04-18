print "Migrate 'stream.Close()' usages to 'stream.Dispose()'"

filepath = "./Parsing/Scanner.cs"

IO.write(
    filepath,
    File.open(filepath, "r:utf-8") do |f|
        f.read.gsub(/stream\.Close/, "stream.Dispose")
    end
)
