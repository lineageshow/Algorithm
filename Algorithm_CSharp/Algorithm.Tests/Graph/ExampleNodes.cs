using Algorithm.Graph;

namespace Algorithm.Tests.Graph;

public class ExampleNodes
{
    public static TreeNode ExampleNode1()
    {
        //[1,null,2,3]
        return new TreeNode(1, null,
            new TreeNode(2, new TreeNode(3), null));
    }

    public static TreeNode ExampleNode2()
    {
        //[]
        return null;
    }

    public static TreeNode ExampleNode3()
    {
        //[1]
        return new TreeNode(1);
    }
    public static TreeNode ExampleNode4()
    {
        //[1,2,3,4,5,null,8,null,null,6,7,9]
        return new TreeNode(1,
            new TreeNode(2, new TreeNode(4), new TreeNode(5, new TreeNode(6), new TreeNode(7))),
            new TreeNode(3, null, new TreeNode(8, new TreeNode(9), null))
        );
    }
}